using Ambev.DeveloperEvaluation.Domain.Events;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Events;

/// <summary>
/// Contains unit tests for the SaleCancelledEvent class.
/// Tests cover initialization with SaleId.
/// </summary>
public class SaleCancelledEventEvent
{
    /// <summary>
    /// Tests that SaleCancelledEvent initializes correctly with SaleId.
    /// </summary>
    [Fact(DisplayName = "SaleCancelledEvent should initialize with SaleId")]
    public void SaleCancelledEvent_ShouldInitializeWithSaleId()
    {
        // Arrange
        var saleId = Guid.NewGuid();

        // Act
        var saleCancelledEvent = new SaleCancelledEvent(saleId);

        // Assert
        Assert.Equal(saleId, saleCancelledEvent.SaleId);
    }
}
