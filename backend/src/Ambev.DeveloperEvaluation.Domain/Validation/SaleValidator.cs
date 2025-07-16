using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
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
