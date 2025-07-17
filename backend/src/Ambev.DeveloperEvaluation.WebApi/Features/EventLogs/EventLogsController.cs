using Ambev.DeveloperEvaluation.Application.EventLogs.ListEventLogs;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.EventLogs.ListEventLogs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Ambev.DeveloperEvaluation.WebApi.Features.EventLogs;

/// <summary>
/// Controller for managing event logs in the application.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EventLogsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the EventLogsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public EventLogsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    /// <summary>
    /// Lists all event logs with optional filters such as event ID, event type, and date range.
    /// </summary>
    /// <param name="request">
    /// The request object containing filtering options such as event ID, event type, date range, and pagination parameters.
    /// </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of event logs matching the specified filters, along with pagination information.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<ListEventLogsResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListSales([FromQuery] ListEventLogsRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<ListEventLogsCommand>(request);

        var validationResult = query.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediator.Send(query, cancellationToken);

        var apiResponse = _mapper.Map<PaginatedResponse<ListEventLogsResponse>>(response);

        apiResponse.Message = "Event logs retrieved successfully";

        apiResponse.Success = true;

        return Ok(apiResponse);
    }

}
