using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
internal class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{

    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Must not be empty and cannot exceed 15 characters.
    /// - Date: Must not be empty and cannot be in the future.
    /// - CustomerId: Must not be empty.
    /// - CustomerName: Must not be empty and cannot exceed 200 characters.
    /// - BranchId: Must not be empty.
    /// - BranchName: Must not be empty and cannot exceed 200 characters.
    /// - Items: Must contain at least one item.
    /// </remarks>
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number cannot be empty.")
            .MaximumLength(15).WithMessage("Sale number cannot exceed 15 characters.");
        RuleFor(sale => sale.Date)
            .NotEmpty().WithMessage("Sale date cannot be empty.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");
        RuleFor(sale => sale.CustomerId)
            .NotEmpty().WithMessage("Customer ID cannot be empty.");
        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("Customer name cannot be empty.")
            .MaximumLength(200).WithMessage("Customer name cannot exceed 200 characters.");
        RuleFor(sale => sale.BranchId)
            .NotEmpty().WithMessage("Branch ID cannot be empty.");
        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("Branch name cannot be empty.")
            .MaximumLength(200).WithMessage("Branch name cannot exceed 200 characters.");
        RuleFor(sale => sale.Items).Must(items => items != null && items.Any())
            .WithMessage("Sale must contain at least one item.");
        RuleForEach(sale => sale.Items)
            .SetValidator(new CreateSaleItemValidator())
            .WithMessage("Each item in the sale must be valid.");



    }
}