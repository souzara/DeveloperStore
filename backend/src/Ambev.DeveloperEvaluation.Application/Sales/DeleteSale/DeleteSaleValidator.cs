using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validation rules for DeleteSaleCommand that ensures the sale ID is provided and not empty.
/// </summary>
internal class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{

    /// <summary>
    /// Initializes a new instance of the DeleteSaleValidator class with validation rules for deleting a sale.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - The sale ID must not be empty.
    /// </remarks>
    public DeleteSaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage("Sale ID must not be empty.");
    }
}