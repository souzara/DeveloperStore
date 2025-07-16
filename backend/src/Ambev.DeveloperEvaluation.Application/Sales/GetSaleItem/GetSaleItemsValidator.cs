using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Validator for GetSaleItemsCommand that defines validation rules for retrieving sale items by sale ID.
/// </summary>
public class GetSaleItemsValidator : AbstractValidator<GetSaleItemsCommand>
{

    /// <summary>
    /// Initializes a new instance of the GetSaleItemsValidator class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - The Sale ID must not be empty.
    /// </remarks>
    public GetSaleItemsValidator()
    {
        RuleFor(command => command.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID must not be empty.");
    }
}
