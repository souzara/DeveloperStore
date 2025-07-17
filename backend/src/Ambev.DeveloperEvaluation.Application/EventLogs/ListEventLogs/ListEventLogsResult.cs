namespace Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;
/// <summary>
/// Represents the result of listing event logs.
/// </summary>
public class ListEventLogsResult
{
    /// <summary>
    /// Unique identifier for the event log.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Unique identifier for the event being logged.
    /// </summary>
    public string EventId { get; set; }

    /// <summary>
    /// Type of the event being logged.
    /// </summary>
    public string? EventType { get; set; }

    /// <summary>
    /// Data associated with the event being logged.
    /// </summary>
    public string? EventData { get; set; }

    /// <summary>
    /// Timestamp indicating when the event log was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
