using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleItemTestData
{

    /// <summary>
    /// Configures the Faker to generate valid SaleItem entities.
    /// The generated sale items will have valid:
    /// - ProductId (GUID)
    /// - ProductName (random product name)
    /// - Quantity (random integer between 1 and 100)
    /// - UnitPrice (random decimal between 1.0 and 1000.0)
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .CustomInstantiator(f => new SaleItem(
            f.Random.Guid(),
            f.Commerce.ProductName(),
            f.Random.Int(1, 20),
            f.Finance.Amount(1.0m, 1000.0m)));

    /// <summary>
    /// Generates a valid SaleItem list with randomized data.
    /// </summary>
    /// <returns>A valid sale item list.</returns>
    internal static List<SaleItem> GenerateValidSaleItemList()
    {
        return SaleItemFaker.Generate(5);
    }

    /// <summary>
    /// Generates a single valid SaleItem with randomized data.
    /// </summary>
    /// <returns>A valid sale item</returns>
    internal static SaleItem GenerateValidSaleItem()
    {
        return SaleItemFaker.Generate();
    }

    /// <summary>
    /// Generates a SaleItem with an invalid ProductId (empty GUID).
    /// </summary>
    /// <returns>A cancelled sale item</returns>
    internal static SaleItem GenerateCancelledSaleItem()
    {
        var saleItem = SaleItemFaker.Generate();
        saleItem.Cancel();
        return saleItem;
    }


    /// <summary>
    /// Generates a valid Product identifier using Faker.
    /// </summary>
    /// <returns>A valid product identifier</returns>
    public static Guid GenerateValidProductId()
    {
        return new Faker().Random.Guid();
    }

    /// <summary>
    /// Generates a valid product name using Faker.
    /// </summary>
    /// <returns>A valid product name</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Generates a valid quantity using Faker.
    /// </summary>
    /// <returns>A valid quantity</returns>
    public static int GenerateValidQuantity()
    {
        return new Faker().Random.Int(1, 20);
    }

    /// <summary>
    /// Generates a valid unit price using Faker.
    /// </summary>
    /// <returns>A valid unit price</returns>
    public static decimal GenerateValidUnitPrice()
    {
        return new Faker().Finance.Amount(1.0m, 1000.0m);
    }

}
