using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Events;

/// <summary>
/// Contains unit tests for the SaleModifiedEvent class.
/// Tests cover initialization with SaleId.
/// </summary>
public class SaleModifiedEventTests
{
    /// <summary>
    /// Tests that SaleModifiedEvent initializes correctly with SaleId.
    /// </summary>
    [Fact(DisplayName = "SaleModifiedEvent should initialize with SaleId")]
    public void SaleModifiedEvent_ShouldInitializeWithSaleId()
    {
        // Arrange
        var saleId = Guid.NewGuid();
        // Act
        var saleModifiedEvent = new Ambev.DeveloperEvaluation.Domain.Events.SaleModifiedEvent(saleId);
        // Assert
        Assert.Equal(saleId, saleModifiedEvent.SaleId);
    }
}
