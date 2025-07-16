using Ambev.DeveloperEvaluation.Domain.Events;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Events;

/// <summary>
/// Contains unit tests for the ItemCancelledEvent class.   
/// Tests cover initialization and property access.
/// </summary>
public class ItemCancelledEventTests
{
    /// <summary>
    /// Tests that the ItemCancelledEvent initializes with the correct SaleItemId.
    /// </summary>
    [Fact(DisplayName = "ItemCancelledEvent should initialize with SaleItemId")]
    public void ItemCancelledEvent_ShouldInitializeWithSaleItemId()
    {
        // Arrange
        var saleItemId = Guid.NewGuid();
        // Act
        var itemCancelledEvent = new ItemCancelledEvent(saleItemId);
        // Assert
        Assert.Equal(saleItemId, itemCancelledEvent.SaleItemId);
    }
}
