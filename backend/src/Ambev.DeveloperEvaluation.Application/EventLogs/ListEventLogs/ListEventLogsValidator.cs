using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;

/// <summary>
/// Validator for the ListEventLogsCommand to ensure that the command's properties meet specified validation criteria.
/// </summary>
internal class ListEventLogsValidator : AbstractValidator<ListEventLogsCommand>
{

    /// <summary>
    /// Initializes a new instance of the ListEventLogsValidator class.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// </remarks>
    public ListEventLogsValidator()
    {

        RuleFor(command => command.EventId)
           .MaximumLength(50)
           .WithMessage("EventId cannot exceed 50 characters.");

        RuleFor(command => command.EventType)
            .MaximumLength(1000)
            .WithMessage("EventType cannot exceed 100 characters.");

        RuleFor(x => x.FromDate)
            .LessThanOrEqualTo(x => x.ToDate).When(x => x.ToDate.HasValue)
            .WithMessage("FromDate must be less than or equal to ToDate.");

        RuleFor(command => command.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(command => command.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage("PageSize must be between 1 and 200.");
    }
}