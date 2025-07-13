using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the SaleValidator class.
/// Tests cover validation of all sale properties including SaleNumber, SaleDate,
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }


    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Valid Sale should pass all validation rules")]
    public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails for invalid SaleNumber formats.
    /// </summary>   
    [Theory(DisplayName = "Sale with SaleNumber longer than 15 characters should fail validation")]
    [InlineData(16)]
    [InlineData(20)]
    public void Given_SaleWithLongSaleNumber_When_Validated_Then_ShouldHaveError(int saleNumberLength)
    {
        // Arrange
        var saleNumber = new string('A', saleNumberLength);
        var saleDate = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        var sale = new Sale(saleNumber, saleDate, customerId, customerName, branchId, branchName);

        // Act
        var result = _validator.TestValidate(sale);
        // Assert
        result.ShouldHaveValidationErrorFor(s => s.SaleNumber)
            .WithErrorMessage("Sale number cannot exceed 15 characters.");
    }

    /// <summary>
    /// Tests that validation fails for invalid SaleDate formats.
    /// </summary>
    [Theory(DisplayName = "Sale with CustomerName longer than 200 characters should fail validation")]
    [InlineData(201)]
    [InlineData(250)]
    public void Given_SaleWithLongCustomerName_When_Validated_Then_ShouldHaveError(int customerNameLength)
    {
        // Arrange
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var saleDate = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = new string('A', customerNameLength);
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = SaleTestData.GenerateValidBranchName();
        var sale = new Sale(saleNumber, saleDate, customerId, customerName, branchId, branchName);
        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(s => s.CustomerName)
            .WithErrorMessage("Customer name cannot exceed 200 characters.");
    }

    /// <summary>
    /// Tests that validation fails for invalid CustomerId formats.
    /// </summary>    
    [Theory(DisplayName = "Sale with BranchName longer than 200 characters should fail validation")]
    [InlineData(201)]
    [InlineData(250)]
    public void Given_SaleWithLongBranchName_When_Validated_Then_ShouldHaveError(int branchNameLength)
    {
        // Arrange
        var saleNumber = SaleTestData.GenerateValidSaleNumber();
        var saleDate = SaleTestData.GenerateValidSaleDate();
        var customerId = SaleTestData.GenerateValidCustomerId();
        var customerName = SaleTestData.GenerateValidCustomerName();
        var branchId = SaleTestData.GenerateValidBranchId();
        var branchName = new string('A', branchNameLength);
        var sale = new Sale(saleNumber, saleDate, customerId, customerName, branchId, branchName);
        // Act
        var result = _validator.TestValidate(sale);
        // Assert
        result.ShouldHaveValidationErrorFor(s => s.BranchName)
            .WithErrorMessage("Branch name cannot exceed 200 characters.");
    }

}
