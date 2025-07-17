using Ambev.DeveloperEvaluation.Application.Common;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;

/// <summary>
/// Represents a command to list event logs with various filtering options.
/// </summary>
public class ListEventLogsCommand : IRequest<PaginatedResult<ListEventLogsResult>>
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
    public int Page { get; set; }
    /// <summary>
    /// Gets or sets the page size for pagination. Defaults to 20.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Validates the current instance of <see cref="ListEventLogsCommand"/> using the <see cref="ListEventLogsValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new ListEventLogsValidator();
        return validator.Validate(this);
    }
}
