using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

public class CreateSaleItemProfile : Profile
{
    public CreateSaleItemProfile()
    {
        CreateMap<CreateSaleItemCommand, SaleItem>()
            .ConstructUsing(p => new SaleItem(p.ProductId, p.ProductName, p.Quantity, p.UnitPrice));
        CreateMap<SaleItem, CreateSaleItemResult>();
    }
}
