using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation.Results;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for canceling an existing sale.
/// </summary>
/// <remarks>
/// This command is part of the application layer and is used to handle the
/// This command is used to capture the required data for canceling a sale,
/// including the unique identifier of the sale to be canceled.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// The data provided in this command is validated using the
/// <see cref="CancelSaleValidator"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CancelSaleCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale to be canceled.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Validates the current instance of <see cref="CancelSaleCommand"/> using the <see cref="CancelSaleValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new CancelSaleValidator();
        return validator.Validate(this);
    }
}