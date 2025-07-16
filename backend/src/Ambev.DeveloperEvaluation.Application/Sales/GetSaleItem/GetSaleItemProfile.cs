using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;

/// <summary>
/// Profile for mapping between SaleItem entity and GetSaleItemResult.
/// </summary>
public class GetSaleItemProfile : Profile
{

    /// <summary>
    /// Initializes the mappings for GetSaleItem operation
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<SaleItem, GetSaleItemResult>();
    }
}
