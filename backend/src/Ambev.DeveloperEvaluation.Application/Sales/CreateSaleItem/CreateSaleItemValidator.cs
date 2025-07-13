using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

/// <summary>
/// Validator for CreateSaleItemCommand that defines validation rules for sale item creation command.
/// </summary>
internal class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Must not be empty.
    /// - ProductName: Must not be empty and cannot exceed 200 characters.
    /// - Quantity: Must be greater than zero and cannot exceed 20.
    /// - UnitPrice: Must be greater than zero.
    /// </remarks>
    public CreateSaleItemValidator()
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