using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.EventLogs.ListEventLogs;

/// <summary>
/// Profile for mapping between Application and API ListEventLogs responses
/// </summary>
public class ListEventLogsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListEventLogs feature  
    /// </summary>
    public ListEventLogsProfile()
    {
        CreateMap<ListEventLogsRequest, ListEventLogsCommand>();
        CreateMap<ListEventLogsResult, ListEventLogsResponse>();

        CreateMap<PaginatedResult<ListEventLogsResult>, PaginatedResponse<ListEventLogsResponse>>()
           .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Items))
           .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(src => src.Page))
           .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
           .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalItems));

    }
}
