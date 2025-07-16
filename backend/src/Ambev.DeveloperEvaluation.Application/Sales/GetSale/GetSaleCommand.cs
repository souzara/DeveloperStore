using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation.Results;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command to get a sale by its unique identifier.
/// </summary>
/// <remarks>
/// This command is part of the application layer and is used to handle the
/// This command is used to capture the required data for retrieving a sale
/// including the unique identifier of the sale to be retrieved.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// The data provided in this command is validated using the
/// <see cref="GetSaleCommand"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class GetSaleCommand : IRequest<GetSaleResult?>
{
    /// <summary>
    /// Gets the unique identifier of the sale to be retrieved.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleCommand"/> class with the specified sale ID.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to be retrieved.</param>
    public GetSaleCommand(Guid id)
    {
        Id = id;
    }


    /// <summary>
    /// Validates the current instance of <see cref="GetSaleCommand"/> using the <see cref="GetSaleValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new GetSaleValidator();
        return validator.Validate(this);
    }
}