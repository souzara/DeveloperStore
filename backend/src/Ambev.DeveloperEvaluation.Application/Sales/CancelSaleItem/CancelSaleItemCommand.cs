using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Command to get sale items for a specific sale.
/// </summary>
/// <remarks>
/// This command is part of the application layer and is used to handle the
/// This command is used to capture the required data for canceling a sale item
/// including the unique identifier of the sale to be retrieved.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// The data provided in this command is validated using the
/// <see cref="CancelSaleItemCommand"/> which extends
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CancelSaleItemCommand : IRequest<bool>
{
    /// <summary>
    /// The unique identifier of the sale from which the item will be canceled.
    /// </summary>
    public Guid SaleId { get; set; }
    /// <summary>
    /// The unique identifier of the item to be canceled in the sale.
    /// </summary>
    public Guid ItemId { get; set; }


    /// <summary>
    /// Initializes a new instance of the CancelSaleItemCommand class.
    /// </summary>
    /// <param name="saleId">
    /// The unique identifier of the sale from which the item will be canceled.
    /// </param>
    /// <param name="itemId">
    /// The unique identifier of the item to be canceled in the sale.
    /// </param>
    public CancelSaleItemCommand(Guid saleId, Guid itemId)
    {
        SaleId = saleId;
        ItemId = itemId;
    }

    /// <summary>
    /// Validates the current instance of <see cref="CancelSaleItemCommand"/> using the <see cref="CancelSaleItemValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new CancelSaleItemValidator();
        return validator.Validate(this);
    }
}
