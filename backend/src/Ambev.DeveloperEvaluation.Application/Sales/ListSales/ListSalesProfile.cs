using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Filters.Sale;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Profile for mapping between paginated Sale and paginated GetSaleResult.
/// </summary>
public class ListSalesProfile : Profile
{

    /// <summary>
    /// Initializes the mappings for ListSale operation
    /// </summary>
    public ListSalesProfile()
    {
        CreateMap<PaginatedData<Sale>, PaginatedResult<GetSaleResult>>();

        CreateMap<ListSalesCommand, SaleFilter>()
            .ConstructUsing(p => new SaleFilter(p.SaleIds,
                                                p.SaleNumber,
                                                p.BranchId,
                                                p.BranchName,
                                                p.CustomerId,
                                                p.CustomerName,
                                                p.FromDate,
                                                p.ToDate,
                                                p.IsCancelled,
                                                p.IncludeItems,
                                                p.Page,
                                                p.PageSize
                                                ));
    }
}
