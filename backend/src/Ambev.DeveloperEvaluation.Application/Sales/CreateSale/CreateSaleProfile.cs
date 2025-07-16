using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between CreateSaleCommand and Sale entity
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>()
            .ConstructUsing(p => new Sale(p.SaleNumber, p.Date, p.CustomerId, p.CustomerName, p.BranchId, p.BranchName));

        CreateMap<Sale, CreateSaleResult>();
    }
}
