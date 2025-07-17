using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
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

        CreateMap<Sale, SaleCreatedEvent>()
            .ConstructUsing(p => new SaleCreatedEvent(p.Id));

        CreateMap<Sale, SaleModifiedEvent>()
            .ConstructUsing(p => new SaleModifiedEvent(p.Id));

        CreateMap<Sale, SaleCancelledEvent>()
            .ConstructUsing(p => new SaleCancelledEvent(p.Id));

    }
}
