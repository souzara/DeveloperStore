namespace Ambev.DeveloperEvaluation.Domain.Filters.EventLogs;

/// <summary>
/// Filter class for querying event logs.
/// </summary>
public class EventLogsFilter
{
    /// <summary>
    /// Unique identifier for the event being logged.
    /// </summary>
    public string? EventId { get; private set; }

    /// <summary>
    /// Type of the event being logged.
    /// </summary>
    public string? EventType { get; private set; }

    /// <summary>
    /// From date to filter events. If null, it will not filter by date range.
    /// </summary>
    public DateTime? FromDate { get; private set; }
    /// <summary>
    /// To date to filter events. If null, it will not filter by date range.
    /// </summary>
    public DateTime? ToDate { get; private set; }

    /// <summary>
    /// Gets or sets the page number for pagination. Defaults to 1.
    /// </summary>
    public int Page { get; private set; }
    /// <summary>
    /// Gets or sets the page size for pagination. Defaults to 20.
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Initializes a new instance of the EventLogsFilter class with the specified parameters.
    /// </summary>
    /// <param name="eventId">Event identifier to filter by. If empty, it will not filter by event identifier.</param>
    /// <param name="eventType">Event type to filter by. If null, it will not filter by event type.</param>
    /// <param name="fromDate">From date to filter events. If null, it will not filter by date range.</param>
    /// <param name="toDate">To date to filter events. If null, it will not filter by date range.</param>
    /// <param name="page">Page number for pagination. Defaults to 1.</param>
    /// <param name="pageSize">Page size for pagination. Defaults to 20.</param>
    public EventLogsFilter(string? eventId, string? eventType, DateTime? fromDate, DateTime? toDate, int page, int pageSize)
    {
        EventId = eventId;
        EventType = eventType;
        FromDate = fromDate;
        ToDate = toDate;
        Page = page;
        PageSize = pageSize;
    }
}
