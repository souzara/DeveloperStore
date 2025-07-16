using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Profile for mapping between GetSaleResult and GetSaleResponse
/// </summary>
public class GetSaleProfile : Profile
{

    /// <summary>
    /// Initializes the mappings for GetSale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
