using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Validator for CancelSaleItemCommand that defines validation rules for canceling an item in a sale.
/// </summary>
public class CancelSaleItemValidator : AbstractValidator<CancelSaleItemCommand>
{

    /// <summary>
    /// Initializes a new instance of the CancelSaleItemValidator class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - The SaleId must not be empty.
    /// - The ItemId must not be empty.
    /// </remarks>
    public CancelSaleItemValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("SaleId is required.");
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .WithMessage("ItemId is required.");
    }
}
