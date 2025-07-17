using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities    .
    /// The generated sales will have valid:
    /// 
    /// - Username (using internet usernames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
     .CustomInstantiator(f => new Sale(
         f.Random.AlphaNumeric(15).ToUpperInvariant(),
         f.Date.Past(1),
         f.Random.Guid(),
         f.Name.FullName(),
         f.Random.Guid(),
         f.Company.CompanyName())
     );


    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated sale will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale()
    {
        return SaleFaker.Generate();
    }

    /// <summary>
    /// Generates a valid Sale entity based on the provided CreateSaleCommand.
    /// </summary>
    /// <param name="createSaleCommand">Create sale command</param>
    /// <returns>A valid Sale entity populated with data from the CreateSaleCommand.</returns>
    public static Sale GenerateValidSale(CreateSaleCommand createSaleCommand)
    {
        var sale = new Sale(createSaleCommand.SaleNumber,
                        createSaleCommand.Date,
                        createSaleCommand.CustomerId,
                        createSaleCommand.CustomerName,
                        createSaleCommand.BranchId,
                        createSaleCommand.BranchName);

        foreach (var item in createSaleCommand.Items)
            sale.Items.Add(new SaleItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice));

        return sale;
    }


    /// <summary>
    /// Generates a valid sale number using Faker.
    /// </summary>
    /// <returns>A valid sale number</returns>
    public static string GenerateValidSaleNumber()
    {
        return new Faker().Random.AlphaNumeric(15).ToUpperInvariant();
    }

    /// <summary>
    /// Generates a valid sale date using Faker.
    /// </summary>
    /// <returns>A valid sale date</returns>
    public static DateTime GenerateValidSaleDate()
    {
        return new Faker().Date.Past(1);
    }

    /// <summary>
    /// Generates a valid customer identifier using Faker.
    /// </summary>
    /// <returns>A valid customer identifier</returns>
    public static Guid GenerateValidCustomerId()
    {
        return new Faker().Random.Guid();
    }

    /// <summary>
    /// Generates a valid customer name using Faker.
    /// </summary>
    /// <returns>A valid customer name</returns>
    public static string GenerateValidCustomerName()
    {
        return new Faker().Name.FullName();
    }

    /// <summary>
    /// Generates a valid branch identifier using Faker.
    /// </summary>
    /// <returns>A valid branch identifier</returns>
    public static Guid GenerateValidBranchId()
    {
        return new Faker().Random.Guid();
    }

    /// <summary>
    /// Generates a valid branch name using Faker.
    /// </summary>
    /// <returns>A valid branch name</returns>
    public static string GenerateValidBranchName()
    {
        return new Faker().Company.CompanyName();
    }
}
