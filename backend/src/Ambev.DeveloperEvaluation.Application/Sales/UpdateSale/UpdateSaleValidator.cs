using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validatpr for UpdateSaleCommand that defines validation rules for sale update command.
/// </summary>
internal class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{

    /// <summary>
    /// Initializes a new instance of the UpdateSaleValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Must not be empty and cannot exceed 15 characters.
    /// - Date: Must not be empty and cannot be in the future.
    /// - CustomerId: Must not be empty.
    /// - CustomerName: Must not be empty and cannot exceed 200 characters.
    /// - BranchId: Must not be empty.
    /// - BranchName: Must not be empty and cannot exceed 200 characters.
    /// </remarks>
    public UpdateSaleValidator()
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
    }
}