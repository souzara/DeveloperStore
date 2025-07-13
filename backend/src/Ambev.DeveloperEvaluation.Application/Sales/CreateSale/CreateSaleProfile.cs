using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
public class CreateSaleProfile : Profile
{

    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ConstructUsing(p => new Sale(p.SaleNumber, p.Date, p.CustomerId, p.CustomerName, p.BranchId, p.BranchName));

        CreateMap<Sale, CreateSaleResult>();
    }
}
