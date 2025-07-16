using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Validator for ListSaleCommand that defines validation rules for retrieving a list of sales.
/// </summary>
internal class ListSalesValidator : AbstractValidator<ListSalesCommand>
{

    /// <summary>
    /// Initializes a new instance of the ListSaleValidator class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleIds must not be null and must contain at least one SaleId.
    /// - SaleNumber must not exceed 50 characters.
    /// - BranchId must not be null.
    /// - BranchName must not exceed 100 characters.
    /// - CustomerId must not be null.
    /// - CustomerName must not exceed 100 characters.
    /// - FromDate must be less than or equal to ToDate if ToDate is provided.
    /// - ToDate must be greater than or equal to FromDate if FromDate is provided.
    /// - Page must be greater than 0.
    /// - PageSize must be between 1 and 200.
    /// </remarks>
    public ListSalesValidator()
    {

        RuleFor(command => command.SaleNumber)
            .MaximumLength(50)
            .WithMessage("SaleNumber cannot exceed 50 characters.");

        RuleFor(command => command.BranchName)
            .MaximumLength(100)
            .WithMessage("BranchName cannot exceed 100 characters.");
        RuleFor(command => command.CustomerName)
            .MaximumLength(100)
            .WithMessage("CustomerName cannot exceed 100 characters.");

        RuleFor(command => command.FromDate)
            .LessThanOrEqualTo(command => command.ToDate)
            .When(command => command.ToDate.HasValue)
            .WithMessage("FromDate must be less than or equal to ToDate.");

        RuleFor(command => command.ToDate)
            .GreaterThanOrEqualTo(command => command.FromDate)
            .When(command => command.FromDate.HasValue)
            .WithMessage("ToDate must be greater than or equal to FromDate.");
        RuleFor(command => command.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");
        RuleFor(command => command.PageSize)
            .InclusiveBetween(1, 200)
            .WithMessage("PageSize must be between 1 and 200.");

    }
}