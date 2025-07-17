using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;
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
    }
}
