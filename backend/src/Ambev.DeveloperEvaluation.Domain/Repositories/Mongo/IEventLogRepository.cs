using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;
using Ambev.DeveloperEvaluation.Domain.Filters.EventLogs;

namespace Ambev.DeveloperEvaluation.Domain.Repositories.Mongo;
/// <summary>
/// Interface for the event log repository.
/// </summary>
public interface IEventLogRepository
{
    /// <summary>
    /// Asynchronously creates a new event log in the repository.
    /// </summary>
    /// <param name="eventLog">Event log to be created.</param>
    Task CreateAsync(EventLog eventLog);

    /// <summary>
    /// Asynchronously retrieves a paginated list of event logs based on the provided filter criteria.
    /// </summary>
    /// <param name="eventLogsFilter">Event logs filter containing criteria such as event type, date range, and pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Event logs that match the filter criteria, including pagination information.</returns>
    Task<PaginatedData<EventLog>> ListAsync(EventLogsFilter eventLogsFilter, CancellationToken cancellationToken = default);
}
