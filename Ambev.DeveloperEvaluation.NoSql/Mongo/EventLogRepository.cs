using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;
using Ambev.DeveloperEvaluation.Domain.Filters.EventLogs;
using Ambev.DeveloperEvaluation.Domain.Repositories.Mongo;
using MongoDB.Driver;

namespace Ambev.DeveloperEvaluation.NoSql.Mongo
{
    /// <summary>
    /// Repository for managing event logs in MongoDB.
    /// </summary>
    public class EventLogRepository : IEventLogRepository
    {
        private readonly IMongoCollection<EventLog> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogRepository"/> class with the specified MongoDB database.
        /// </summary>
        public EventLogRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<EventLog>("EventLogs");
        }


        /// <summary>
        /// Asynchronously creates a new event log in the repository.
        /// </summary>
        /// <param name="eventLog">Event log to be created.</param>
        public Task CreateAsync(EventLog eventLog)
        {
            if (eventLog == null)
                throw new ArgumentNullException(nameof(eventLog), "Event log cannot be null.");

            return _collection.InsertOneAsync(eventLog);
        }

        /// <summary>
        /// Asynchronously retrieves a paginated list of event logs based on the provided filter criteria.
        /// </summary>
        /// <param name="eventLogsFilter">Event logs filter containing criteria such as event type, date range, and pagination parameters.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Event logs that match the filter criteria, including pagination information.</returns>
        public async Task<PaginatedData<EventLog>> ListAsync(EventLogsFilter eventLogsFilter, CancellationToken cancellationToken = default)
        {
            var filterBuilder = Builders<EventLog>.Filter;

            var filters = new List<FilterDefinition<EventLog>>();

            if (!string.IsNullOrEmpty(eventLogsFilter.EventId))
                filters.Add(filterBuilder.Eq(el => el.EventId, eventLogsFilter.EventId));

            if (!string.IsNullOrEmpty(eventLogsFilter.EventType))
                filters.Add(filterBuilder.Eq(el => el.EventType, eventLogsFilter.EventType));

            if (eventLogsFilter.FromDate.HasValue && eventLogsFilter.ToDate.HasValue)
                filters.Add(filterBuilder.Gte(el => el.CreatedAt, eventLogsFilter.FromDate.Value) &
                             filterBuilder.Lte(el => el.CreatedAt, eventLogsFilter.ToDate.Value));

            var combinedFilter = filters.Any() ? filterBuilder.And(filters) : Builders<EventLog>.Filter.Empty;

            var totalCount = await _collection.CountDocumentsAsync(combinedFilter, cancellationToken: cancellationToken);

            var events = await _collection.Find(combinedFilter)
                .Skip((eventLogsFilter.Page - 1) * eventLogsFilter.PageSize)
                .Limit(eventLogsFilter.PageSize)
                .ToListAsync(cancellationToken);

            return new PaginatedData<EventLog>(events, eventLogsFilter.Page, eventLogsFilter.PageSize, totalCount);
        }
    }
}
