using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
public static class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(u => u.SaleNumber, f => f.Random.AlphaNumeric(10))
        .RuleFor(u => u.Date, f => f.Date.Past(1))
        .RuleFor(u => u.CustomerId, f => f.Random.Guid())
        .RuleFor(u => u.CustomerName, f => f.Name.FullName())
        .RuleFor(u => u.BranchId, f => f.Random.Guid())
        .RuleFor(u => u.BranchName, f => f.Company.CompanyName())
        .RuleFor(u => u.Items, f => f.Make(f.Random.Number(1, 5), () => CreateSaleItemHandlerTestData.createSaleItemHandlerFaker.Generate()));

    private static readonly Faker<CreateSaleResult> createSaleResultFaker = new Faker<CreateSaleResult>()
        .RuleFor(u => u.Id, f => f.Random.Guid());

    internal static CreateSaleResult GenerateCreateSaleResult(Sale sale)
    {
        return new CreateSaleResult
        {
            Id = sale.Id
        };
    }

    internal static CreateSaleCommand GenerateValid()
    {
        return createSaleHandlerFaker.Generate();
    }
}
