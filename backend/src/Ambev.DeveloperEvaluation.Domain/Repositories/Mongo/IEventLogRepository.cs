using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;

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
}
