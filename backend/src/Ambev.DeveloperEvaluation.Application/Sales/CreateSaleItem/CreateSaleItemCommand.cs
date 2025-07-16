using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

/// <summary>
/// Command for creating a new sale item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a sale item. 
/// including product details, quantity, and price.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request.
/// 
/// The data provided in this command is validated using the
/// <see cref="CreateSaleItemCommand"/> which extends"/>
/// <see cref="AbstracValidador{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleItemCommand : IRequest<CreateSaleItemResult>
{
    /// <summary>
    /// Gets or sets the unique identifier for the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// Gets or sets the name of the product associated with the sale item.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the quantity of the product in the sale item.
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Gets or sets the unit price of the product in the sale item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the sale to which this item belongs.
    /// </summary>
    public Guid SaleId { get; set; }


    /// <summary>
    /// Validates the current instance of <see cref="CreateSaleItemCommand"/> using the <see cref="CreateSaleItemValidator"/>.
    /// </summary>
    /// <returns>ValidationResultDetail containing the validation status and any errors encountered during validation.</returns>
    public ValidationResult Validate()
    {
        var validator = new CreateSaleItemValidator();
        return validator.Validate(this);
    }

}