using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetSaleCommand that defines validation rules for retrieving a sale by its ID.
/// </summary>
internal class GetSaleValidator : AbstractValidator<GetSaleCommand>
{

    /// <summary>
    /// Initializes a new instance of the GetSaleValidator class with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - The Sale ID must not be empty.
    /// </remarks>
    public GetSaleValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEmpty()
            .WithMessage("Sale ID must not be empty.");
    }
}