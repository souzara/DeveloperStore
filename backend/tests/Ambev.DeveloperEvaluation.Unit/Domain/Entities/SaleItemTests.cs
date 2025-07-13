using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;


/// <summary>
/// Contains unit tests for the SaleItem entity class.
/// </summary>
public class SaleItemTests
{

    /// <summary>
    /// Tests that creating a SaleItem with an empty ProductId throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating SaleItem with empty ProductId should throw ArgumentException")]
    public void Given_EmptyProductId_When_CreatingSaleItem_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var productId = Guid.Empty;
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = SaleItemTestData.GenerateValidQuantity();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SaleItem(productId, productName, quantity, unitPrice));
    }

    /// <summary>
    /// Tests that creating a SaleItem with an empty ProductName throws an ArgumentException.
    /// </summary>
    [Theory(DisplayName = "Creating SaleItem with null or white space ProductName should throw ArgumentException")]
    [InlineData(null)]
    [InlineData("")]
    public void Given_EmptyProductName_When_CreatingSaleItem_Then_ShouldThrowArgumentException(string? productName)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var quantity = SaleItemTestData.GenerateValidQuantity();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SaleItem(productId, productName, quantity, unitPrice));
    }

    /// <summary>
    /// Tests that creating a SaleItem with zero or negative Quantity throws an ArgumentException.
    /// </summary>
    [Theory(DisplayName = "Creating SaleItem with zero or negative Quantity should throw ArgumentException")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Given_ZeroOrNegativeQuantity_When_CreatingSaleItem_Then_ShouldThrowArgumentException(int quantity)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SaleItem(productId, productName, quantity, unitPrice));
    }

    /// <summary>
    /// Tests that creating a SaleItem with Quantity greater than 20 throws an ArgumentException.
    /// </summary>
    [Fact(DisplayName = "Creating SaleItem with Quantity greater than 20 should throw ArgumentException")]
    public void Given_QuantityGreaterThan20_When_CreatingSaleItem_Then_ShouldThrowArgumentException()
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = 21;
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SaleItem(productId, productName, quantity, unitPrice));
    }

    /// <summary>
    /// Tests that creating a SaleItem with zero or negative UnitPrice throws an ArgumentException.
    /// </summary>
    [Theory(DisplayName = "Creating SaleItem with zero or negative UnitPrice should throw ArgumentException")]
    [InlineData(0)]
    [InlineData(-1)]
    public void Given_ZeroOrNegativeUnitPrice_When_CreatingSaleItem_Then_ShouldThrowArgumentException(decimal unitPrice)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = SaleItemTestData.GenerateValidQuantity();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new SaleItem(productId, productName, quantity, unitPrice));
    }

    /// <summary>
    /// Tests that creating a SaleItem with valid parameters succeeds and initializes properties correctly.
    /// </summary>
    [Fact(DisplayName = "Creating SaleItem with valid parameters should succeed")]
    public void Given_ValidParameters_When_CreatingSaleItem_Then_ShouldSucceed()
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = SaleItemTestData.GenerateValidQuantity();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        var startTestAt = DateTime.UtcNow;
        // Act
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);
        // Assert
        Assert.NotNull(saleItem);
        Assert.Equal(productId, saleItem.ProductId);
        Assert.Equal(productName, saleItem.ProductName);
        Assert.Equal(quantity, saleItem.Quantity);
        Assert.Equal(unitPrice, saleItem.UnitPrice);
        Assert.True(saleItem.CreatedAt > startTestAt);
        Assert.Null(saleItem.UpdatedAt);
        Assert.False(saleItem.IsCancelled);
    }

    /// <summary>
    /// Tests that calculating the discount for a SaleItem with quantity less than 4 returns zero.
    /// </summary>
    [Fact(DisplayName = "Calculating discount for SaleItem with quantity less than 4 should return zero")]
    public void Given_QuantityLessThan4_When_CalculatingDiscount_Then_ShouldReturnZero()
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = 3; // Less than 4
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);

        // Act
        var discount = saleItem.Discount;

        // Assert
        Assert.Equal(0, discount);
    }

    /// <summary>
    /// Tests that calculating the discount for a SaleItem with quantity between 4 and 9 returns a 10% discount.
    /// </summary>
    [Theory(DisplayName = "Calculating discount for SaleItem with quantity between 4 and 9 should return 10% discount")]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    public void Given_QuantityBetween4And9_When_CalculatingDiscount_Then_ShouldReturn10PercentDiscount(int quantity)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        var correctDiscount = quantity * unitPrice * 0.10m;
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);
        // Act
        var discount = saleItem.Discount;
        // Assert
        Assert.Equal(correctDiscount, discount);
    }

    /// <summary>
    /// Tests that calculating the discount for a SaleItem with quantity of 10 or more returns a 20% discount.
    /// </summary>
    [Theory(DisplayName = "Calculating discount for SaleItem with quantity 10 or more should return 20% discount")]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(20)]
    public void Given_Quantity10OrMore_When_CalculatingDiscount_Then_ShouldReturn20PercentDiscount(int quantity)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        var correctDiscount = quantity * unitPrice * 0.20m;
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);
        // Act
        var discount = saleItem.Discount;
        // Assert
        Assert.Equal(correctDiscount, discount);
    }

    /// <summary>
    /// Tests that the Total property of a SaleItem calculates the total price after applying the discount.
    /// </summary>
    [Fact(DisplayName = "Cancelling SaleItem should set IsCancelled to true and change updatedAt date")]
    public void Given_SaleItem_When_Cancelling_Then_ShouldSetIsCancelledToTrueAndDiscountToZero()
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = SaleItemTestData.GenerateValidProductName();
        var quantity = SaleItemTestData.GenerateValidQuantity();
        var unitPrice = SaleItemTestData.GenerateValidUnitPrice();
        var startTestAt = DateTime.UtcNow;
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);
        // Act
        saleItem.Cancel();
        // Assert
        Assert.True(saleItem.IsCancelled);
        Assert.NotNull(saleItem.UpdatedAt);
        Assert.True(saleItem.UpdatedAt > startTestAt);
    }

}
