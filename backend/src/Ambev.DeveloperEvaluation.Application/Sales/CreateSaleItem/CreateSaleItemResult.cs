namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

/// <summary>
/// Represents the response returned after successfully creating a new sale item.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created sale item,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleItemResult
{
    /// <summary>
    /// The unique identifier of the created sale item. 
    /// </summary>
    public Guid Id { get; set; }
}