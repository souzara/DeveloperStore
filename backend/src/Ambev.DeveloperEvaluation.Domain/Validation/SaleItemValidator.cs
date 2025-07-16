using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("ProductId cannot be empty.");
            RuleFor(item => item.ProductName)
                .NotEmpty().WithMessage("ProductName cannot be empty.")
                .MaximumLength(200).WithMessage("ProductName cannot exceed 200 characters.");
            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");
            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("UnitPrice must be greater than zero.");
        }
    }
}
