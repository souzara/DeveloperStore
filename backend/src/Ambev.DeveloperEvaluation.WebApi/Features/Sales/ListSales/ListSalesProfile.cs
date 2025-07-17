using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

/// <summary>
/// Profile for mapping between PaginatedResult<GetSaleResult> and PaginatedResponse<GetSaleResponse>.
/// Profile for mapping between GetSaleItemResult and GetSaleItemResponse.
/// </summary>
public class ListSaleProfile : Profile
{

    /// <summary>
    /// Initializes the mappings for ListSaleProfile operation
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<PaginatedResult<GetSaleResult>, PaginatedResponse<GetSaleResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.Page))
            .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalItems));

        CreateMap<ListSalesRequest, ListSalesCommand>();
    }
}
