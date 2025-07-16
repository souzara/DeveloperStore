using Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleItem;

/// <summary>
/// Profile for mapping between GetSaleItemResult and GetSaleItemResponse.
/// </summary>
public class GetSaleItemProfile : Profile
{

    /// <summary>
    /// Initializes the mappings for GetSaleItem operation
    /// </summary>
    public GetSaleItemProfile()
    {
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
    }
}
