using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.TestData;
public static class CreateSaleItemHandlerTestData
{
    public static readonly Faker<CreateSaleItemCommand> createSaleItemHandlerFaker = new Faker<CreateSaleItemCommand>()
        .RuleFor(c => c.ProductId, f => f.Random.Guid())
        .RuleFor(c => c.ProductName, f => f.Commerce.ProductName())
        .RuleFor(c => c.Quantity, f => f.Random.Int(1, 20))
        .RuleFor(c => c.UnitPrice, f => f.Finance.Amount(1, 1000))
        .RuleFor(c => c.SaleId, f => f.Random.Guid());

}