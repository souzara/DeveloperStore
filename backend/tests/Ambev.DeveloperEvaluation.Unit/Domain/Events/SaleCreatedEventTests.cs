using Ambev.DeveloperEvaluation.Domain.Events;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Events;

/// <summary>
/// Contains unit tests for the SaleCreatedEvent class.
/// Tests cover initialization with SaleId.
/// </summary>
public class SaleCreatedEventTests
{
    /// <summary>
    /// Tests that SaleCreatedEvent initializes correctly with SaleId.
    /// </summary>
    [Fact(DisplayName = "SaleCreatedEvent should initialize with SaleId")]
    public void SaleCreatedEvent_ShouldInitializeWithSaleId()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        // Act
        var saleCreatedEvent = new SaleCreatedEvent(saleId);
        // Assert
        Assert.Equal(saleId, saleCreatedEvent.SaleId);
    }
}
