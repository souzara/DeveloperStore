using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Command to get sale items for a specific sale.
/// </summary>
/// <remarks>
/// This command is part of the application layer and is used to handle the
/// This command is used to capture the required data for retrieving sale items
/// including the unique identifier of the sale to be retrieved.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// The data provided in this command is validated using the
/// <see cref="GetSaleItemsCommand"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class GetSaleItemsCommand : IRequest<IEnumerable<GetSaleItemResult>>
{
    /// <summary>
    /// Gets the unique identifier of the sale for which items are to be retrieved.
    /// </summary>
    public Guid SaleId { get; }
    /// <summary>
    /// Initializes a new instance of the <see cref="GetSaleItemsCommand"/> class with the specified sale ID.
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale for which items are to be retrieved.</param>
    public GetSaleItemsCommand(Guid saleId)
    {
        SaleId = saleId;
    }

    /// <summary>
    /// Validates the current instance of <see cref="GetSaleItemsCommand"/> using the <see cref="GetSaleItemsValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new GetSaleItemsValidator();
        return validator.Validate(this);
    }
}
