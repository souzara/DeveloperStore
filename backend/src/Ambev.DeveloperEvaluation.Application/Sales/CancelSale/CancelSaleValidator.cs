using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validation rules for CancelSaleCommand that ensures the sale ID is provided and not empty.
/// </summary>
internal class CancelSaleValidator : AbstractValidator<CancelSaleCommand>
{

    /// <summary>
    /// Initializes a new instance of the CancelSaleValidator class with validation rules for canceling a sale.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - The sale ID must not be empty.
    /// </remarks>
    public CancelSaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage("Sale ID must not be empty.");
    }
}