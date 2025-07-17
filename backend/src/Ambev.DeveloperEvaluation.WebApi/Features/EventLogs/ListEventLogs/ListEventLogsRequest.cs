namespace Ambev.DeveloperEvaluation.WebApi.Features.EventLogs.ListEventLogs;

/// <summary>
/// Represents a request to list event logs with optional filtering and pagination.
/// </summary>
public class ListEventLogsRequest
{
    /// <summary>
    /// Unique identifier for the event being logged.
    /// </summary>
    public string? EventId { get; set; }

    /// <summary>
    /// Type of the event being logged.
    /// </summary>
    public string? EventType { get; set; }

    /// <summary>
    /// From date to filter events. If null, it will not filter by date range.
    /// </summary>
    public DateTime? FromDate { get; set; }
    /// <summary>
    /// To date to filter events. If null, it will not filter by date range.
    /// </summary>
    public DateTime? ToDate { get; set; }

    /// <summary>
    /// Gets or sets the page number for pagination. Defaults to 1.
    /// </summary>
    public int Page { get; set; } = 1;
    /// <summary>
    /// Gets or sets the page size for pagination. Defaults to 20.
    /// </summary>
    public int PageSize { get; set; } = 20;
}
