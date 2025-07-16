using FluentValidation.Results;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting an existing sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for deleting a sale,
/// including the unique identifier of the sale to be deleted.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// The data provided in this command is validated using the
/// <see cref="DeleteSaleValidator"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class DeleteSaleCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Validates the current instance of <see cref="DeleteSaleCommand"/> using the <see cref="DeleteSaleValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new DeleteSaleValidator();
        return validator.Validate(this);
    }
}