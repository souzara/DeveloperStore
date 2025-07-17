using Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities.Mongo;
using Ambev.DeveloperEvaluation.Domain.Filters.EventLogs;
using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// </summary>
public class ListEventLogsProfile : Profile
{

    /// <summary>
    /// </summary>
    public ListEventLogsProfile()
    {
        CreateMap<EventLog, ListEventLogsResult>();

        CreateMap<PaginatedData<EventLog>, PaginatedResult<ListEventLogsResult>>();

        CreateMap<ListEventLogsCommand, EventLogsFilter>()
            .ConstructUsing(p => new EventLogsFilter(p.EventId, p.EventType, p.FromDate, p.ToDate, p.Page, p.PageSize));
    }
}
