namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleItem;

/// <summary>
/// Represents a request to create a new sale item in the system.
/// </summary>
public class CreateSaleItemRequest
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

}
