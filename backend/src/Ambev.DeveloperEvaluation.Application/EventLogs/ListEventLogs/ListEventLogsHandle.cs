using Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;
using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Filters.EventLogs;
using Ambev.DeveloperEvaluation.Domain.Repositories.Mongo;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;

/// <summary>
/// Handler for processing the ListEventLogsCommand to retrieve a paginated list of event logs.
/// </summary>
public class ListEventLogsHandle : IRequestHandler<ListEventLogsCommand, PaginatedResult<ListEventLogsResult>>
{
    private readonly IEventLogRepository _eventLogRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the ListEventLogsHandle class.
    /// </summary>
    /// <param name="saleRepository">The event log repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ListEventLogsHandle(IEventLogRepository eventLogRepository, IMapper mapper)
    {
        _eventLogRepository = eventLogRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListEventLogsCommand to retrieve a paginated list of event logs based on the provided filters.
    /// </summary>
    /// <param name="request">The ListEventLogs command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>paginated result containing a list of event logs that match the specified filters.</returns>
    public async Task<PaginatedResult<ListEventLogsResult>> Handle(ListEventLogsCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salesFilter = _mapper.Map<EventLogsFilter>(request);

        var sales = await _eventLogRepository.ListAsync(salesFilter, cancellationToken);

        return _mapper.Map<PaginatedResult<ListEventLogsResult>>(sales);

    }
}
