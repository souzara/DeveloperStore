using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;
namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover creation, validation, item addition, cancellation, and total amount calculation.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that creating a sale with an empty SaleNumber throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with empty SaleNumber should throw ArgumentException")]
    public void Given_EmptySaleNumber_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var saleNumber = string.Empty;
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with a default DateTime value throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with default DateTime should throw ArgumentException")]
    public void Given_DefaultDateTime_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var saleNumber = string.Empty;
        DateTime date = default;
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with an empty CustomerId throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with empty CustomerId should throw ArgumentException")]
    public void Given_EmptyCustomerId_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var saleNumber = string.Empty;
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = Guid.Empty;
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with an empty CustomerName throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with empty CustomerName should throw ArgumentException")]
    public void Given_EmptyCustomerName_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var saleNumber = string.Empty;
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = string.Empty;
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with an empty BranchId throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with empty BranchId should throw ArgumentException")]
    public void Given_EmptyBranchId_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange

        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = Guid.Empty;
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with an empty BranchName throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating sale with empty BranchName should throw ArgumentException")]
    public void Given_EmptyBranchName_When_CreatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = string.Empty;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Sale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that creating a sale with valid parameters should succeed and create a Sale object with expected properties.
    /// </summary>
    [Fact(DisplayName = "Creating sale with valid parameters should succeed")]
    public void Given_ValidParameters_When_CreatingSale_Then_ShouldSucceed()
    {
        // Arrange
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        var startTestAt = DateTime.UtcNow;

        // Act
        var sale = new Sale(saleNumber, date, customerId, customerName, branchId, branchName);
        // Assert
        Assert.NotNull(sale);
        Assert.Equal(saleNumber, sale.SaleNumber);
        Assert.Equal(date, sale.Date);
        Assert.Equal(customerId, sale.CustomerId);
        Assert.Equal(customerName, sale.CustomerName);
        Assert.Equal(branchId, sale.BranchId);
        Assert.Equal(branchName, sale.BranchName);
        Assert.NotEqual(Guid.Empty, sale.Id);
        Assert.True(sale.CreatedAt > startTestAt);
        Assert.Null(sale.UpdatedAt);
        Assert.False(sale.IsCancelled);
    }

    /// <summary>
    /// Tests that adding items to a sale should update the TotalAmount correctly.
    /// </summary>
    [Fact(DisplayName = "Adding items to sale should update TotalAmount correctly")]
    public void Given_ValidItems_When_AddingItemsToSale_Then_TotalAmountShouldBeUpdatedCorrectly()
    {
        // Arrange / Act
        var sale = SaleTestData.GenerateValidSale();
        for (int i = 0; i < 2; i++)
        {
            var productId = SaleItemTestData.GenerateValidProductId();
            var productName = SaleItemTestData.GenerateValidProductName();
            var quantity = SaleItemTestData.GenerateValidQuantity();
            var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
            sale.AddItem(productId, productName, quantity, unitPrice);
        }

        var totalAmount = sale.Items.Sum(x => x.Total);

        // Assert
        Assert.Equal(totalAmount, sale.TotalAmount);
    }

    /// <summary>
    /// Tests that cancelling a sale should set IsCancelled to true and all items should be marked as cancelled.
    /// </summary>
    [Fact(DisplayName = "Cancelling sale should set IsCancelled to true and items should be cancelled.")]
    public void Given_Sale_When_CancellingSale_Then_IsCancelledShouldBeTrueAndItemsShouldBeCancelled()
    {
        // Arrange
        var startTestAt = DateTime.UtcNow;
        var sale = SaleTestData.GenerateValidSale();
        for (int i = 0; i < 2; i++)
        {
            var productId = SaleItemTestData.GenerateValidProductId();
            var productName = SaleItemTestData.GenerateValidProductName();
            var quantity = SaleItemTestData.GenerateValidQuantity();
            var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
            sale.AddItem(productId, productName, quantity, unitPrice);
        }
        // Act
        sale.Cancel();
        // Assert
        Assert.True(sale.IsCancelled);
        Assert.All(sale.Items, item => Assert.True(item.IsCancelled));
        Assert.NotNull(sale.UpdatedAt);
        Assert.True(sale.UpdatedAt >= startTestAt);
    }


    /// <summary>
    /// Tests that the TotalAmount property should not include cancelled items when calculating the total amount of the sale.
    /// </summary>
    [Fact(DisplayName = "TotalAmount should not include cancelled items")]
    public void Given_SaleWithCancelledItems_When_CalculatingTotalAmount_Then_ShouldNotIncludeCancelledItems()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        var firstSaleItem = SaleItemTestData.GenerateValidSaleItem();
        var secondSaleItem = SaleItemTestData.GenerateCancelledSaleItem();
        sale.AddItem(firstSaleItem);
        sale.AddItem(secondSaleItem);
        // Act
        var totalAmount = sale.TotalAmount;
        // Assert
        Assert.Equal(sale.Items.Where(x => !x.IsCancelled).Sum(x => x.Total), totalAmount);
    }


    /// <summary>
    /// Tests that updating a sale with an empty SaleNumber should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with empty SaleNumber should throw ArgumentException")]
    public void Given_EmptySaleNumber_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = string.Empty;
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with a default DateTime value should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with default DateTime should throw ArgumentException")]
    public void Given_DefaultDateTime_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        DateTime date = default;
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with an empty CustomerId should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with empty CustomerId should throw ArgumentException")]
    public void Given_EmptyCustomerId_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = Guid.Empty;
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with an empty CustomerName should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with empty CustomerName should throw ArgumentException")]
    public void Given_EmptyCustomerName_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = string.Empty;
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with an empty BranchId should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with empty BranchId should throw ArgumentException")]
    public void Given_EmptyBranchId_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = Guid.Empty;
        var branchName = SaleTestData.GenerateValidBranchName();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with an empty BranchName should throw an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Updating sale with empty BranchName should throw ArgumentException")]
    public void Given_EmptyBranchName_When_UpdatingSale_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = string.Empty;
        // Act & Assert
        Assert.Throws<ArgumentException>(() => sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName));
    }

    /// <summary>
    /// Tests that updating a sale with valid parameters should succeed and update the Sale object properties accordingly.
    /// </summary>
    [Fact(DisplayName = "Updating sale with valid parameters should succeed")]
    public void Given_ValidParameters_When_UpdatingSale_Then_ShouldSucceed()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var date = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        var startTestAt = DateTime.UtcNow;
        // Act
        sale.UpdateSale(saleNumber, date, customerId, customerName, branchId, branchName);
        // Assert
        Assert.Equal(saleNumber, sale.SaleNumber);
        Assert.Equal(date, sale.Date);
        Assert.Equal(customerId, sale.CustomerId);
        Assert.Equal(customerName, sale.CustomerName);
        Assert.Equal(branchId, sale.BranchId);
        Assert.Equal(branchName, sale.BranchName);
        Assert.True(sale.UpdatedAt >= startTestAt);
    }
}
