
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Represents the response returned after successfully retrieving a sale.
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Get the unique identifier for the sale.
    /// Must be a valid GUID.
    /// </summary>
    public string SaleNumber { get; private set; }
    /// <summary>
    /// Gets the date of the sale.
    /// Must be a valid date and time.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Gets the unique identifier for the customer associated with the sale.
    /// </summary>
    public Guid CustomerId { get; private set; }
    /// <summary>
    /// Gets the name of the customer associated with the sale.
    /// </summary>
    public string CustomerName { get; private set; }
    /// <summary>
    /// Gets the unique identifier for the branch where the sale was made.
    /// </summary>
    public Guid BranchId { get; private set; }
    /// <summary>
    /// Gets the name of the branch where the sale was made.
    /// </summary>
    public string BranchName { get; private set; }
    /// <summary>
    /// Gets a value indicating whether the sale has been cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }
    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }
    /// <summary>
    /// Gets the date and time when the sale was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets the total amount of the sale, which is the sum of all item totals.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets the collection of items in the sale.
    /// </summary>
    public virtual List<GetSaleItemResponse> Items { get; set; } = new();
}
