using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleItemValidator class.
/// Tests cover validation of all SaleItem properties including ProductId,
/// </summary>
public class SaleItemValidatorTests
{
    private readonly SaleItemValidator _validator;

    public SaleItemValidatorTests()
    {
        _validator = new SaleItemValidator();
    }

    /// <summary>
    /// Tests that validation passes when all SaleItem properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid SaleItem should pass all validation rules")]
    public void Given_ValidSaleItem_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var saleItem = SaleItemTestData.GenerateValidSaleItem();
        // Act
        var result = _validator.TestValidate(saleItem);
        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for empty ProductId.
    /// </summary>
    /// <param name="productNameLength"></param>
    [Theory(DisplayName = "ProductName should not exceed 200 characters")]
    [InlineData(201)]
    [InlineData(250)]
    public void Given_ProductNameExceeding200Characters_When_Validated_Then_ShouldHaveError(int productNameLength)
    {
        // Arrange
        var productId = SaleItemTestData.GenerateValidProductId();
        var productName = new string('A', productNameLength);
        var quantity = SaleItemTestData.GenerateValidSaleItem().Quantity;
        var unitPrice = SaleItemTestData.GenerateValidSaleItem().UnitPrice;
        var saleItem = new SaleItem(productId, productName, quantity, unitPrice);

        // Act
        var result = _validator.TestValidate(saleItem);
        // Assert
        result.ShouldHaveValidationErrorFor(item => item.ProductName)
            .WithErrorMessage("ProductName cannot exceed 200 characters.");
    }
}
