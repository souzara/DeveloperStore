using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Represents the response returned after successfully retrieving a sale item.
/// </summary>
public class GetSaleItemResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale item.
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Gets the unique identifier for the product associated with the sale item.
    /// </summary>
    public Guid ProductId { get; private set; }
    /// <summary>
    /// Gets the name of the product associated with the sale item.
    /// </summary>
    public string ProductName { get; private set; }
    /// <summary>
    /// Gets the quantity of the product in the sale item.
    /// </summary>
    public int Quantity { get; private set; }
    /// <summary>
    /// Gets the unit price of the product in the sale item.
    /// </summary>
    public decimal UnitPrice { get; private set; }
    /// <summary>
    /// Gets the discount applied to the sale item based on quantity and unit price.
    /// </summary>
    public decimal Discount { get; private set; }
    /// <summary>
    /// Calculates the total price for the sale item after applying the discount.
    /// </summary>
    public decimal Total { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the sale item has been cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Gets the date and time when the sale item was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the date and time when the sale item was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }


    /// <summary>
    /// Gets the the sale associated with this sale item.
    /// </summary>
    public virtual Sale Sale { get; private set; }

    /// <summary>
    /// Gets the unique identifier for the sale associated with this sale item.
    /// </summary>
    public Guid SaleId { get; set; }
}
