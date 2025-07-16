using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sales operations
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the SalesController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a paginated list of sales with optional filters
    /// </summary>
    /// <param name="id">The unique identifier of the sale to update.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found, otherwise a NotFound result</returns>
    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSaleCommand(id);

        var response = await _mediator.Send(query, cancellationToken);

        if (response == null)
            return NotFound("Sale not found");

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(response)
        });
    }

    /// <summary>
    /// Lists all sales with optional filters such as customer ID, branch ID, and date range.
    /// </summary>
    /// <param name="request">
    /// The request object containing filtering options such as sale IDs, sale number, branch ID, customer ID, date range, and pagination parameters.
    /// </param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of sales matching the specified filters, along with pagination information.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<GetSaleResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ListSales([FromQuery] ListSalesRequest request, CancellationToken cancellationToken)
    {
        var query = _mapper.Map<ListSalesCommand>(request);

        var validationResult = query.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediator.Send(query, cancellationToken);

        var apiResponse = _mapper.Map<PaginatedResponse<GetSaleResponse>>(response);

        apiResponse.Message = "Sales retrieved successfully";
        apiResponse.Success = true;

        return Ok(apiResponse);
    }

    /// <summary>
    /// Creates a new sale in the system
    /// </summary>
    /// <param name="request">The sale creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateSaleCommand>(request);

        var validationResult = command.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }
    /// <summary>
    /// Updates an existing sale in the system
    /// </summary>
    /// <param name="id">The unique identifier of the sale to update.</param>
    /// <param name="request">Request object containing the updated sale details.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateSaleCommand>(request);
        command.Id = id;

        var validationResult = command.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediator.Send(command, cancellationToken);

        if (!response)
            return NotFound("Sale not found");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale updated successfully"
        });
    }

    /// <summary>
    /// Deletes an existing sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteSaleCommand { Id = id };
        var response = await _mediator.Send(command, cancellationToken);
        if (!response)
            return NotFound("Sale not found");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }

    /// <summary>
    /// Cancels an existing sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>An IActionResult indicating the result of the update operation.</returns>
    [HttpPatch]
    [Route("{id:guid}/cancel")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelSale(Guid id, CancellationToken cancellationToken)
    {
        var command = new CancelSaleCommand { Id = id };
        var response = await _mediator.Send(command, cancellationToken);
        if (!response)
            return NotFound("Sale not found");
        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale cancelled successfully"
        });
    }

    /// <summary>
    /// Retrieves all items associated with a specific sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale for which items are to be retrieved.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>An IActionResult containing a list of sale items if found, or a NotFound result if the sale does not exist.</returns>
    [HttpGet]
    [Route("{id:guid}/items")]
    [ProducesResponseType(typeof(ApiResponseWithData<IEnumerable<GetSaleItemResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleItems(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSaleItemsCommand(id);

        var items = await _mediator.Send(query, cancellationToken);

        if (items == null)
            return NotFound("Sale not found");

        return Ok(new ApiResponseWithData<IEnumerable<GetSaleItemResponse>>
        {
            Success = true,
            Message = "Sale items retrieved successfully",
            Data = _mapper.Map<IEnumerable<GetSaleItemResponse>>(items)
        });
    }

    /// <summary>
    /// Cancels a specific item in a sale by its unique identifier and the item's unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale for which items are to be retrieved.</param>
    /// <param name="itemId">The unique identifier of the item to be cancelled within the sale.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>An IActionResult indicating the success or failure of the cancellation operation.</returns>
    [HttpPatch]
    [Route("{id:guid}/items/{itemId:guid}/cancel")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelSaleItem(Guid id, Guid itemId, CancellationToken cancellationToken)
    {
        var command = new CancelSaleItemCommand(id, itemId);

        var response = await _mediator.Send(command, cancellationToken);

        if (!response)
            return NotFound("Sale or Sale Item not found");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale item cancelled successfully"
        });
    }

    /// <summary>
    /// Creates a new item in an existing sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to which the item will be added.</param>
    /// <param name="request">Request object containing the details of the item to be created, such as product ID, quantity, and price.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>An IActionResult containing the created sale item details if successful, or a BadRequest result if validation fails.</returns>
    [HttpPost]
    [Route("{id:guid}/items")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleItem(Guid id, [FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateSaleItemCommand>(request);

        command.SaleId = id;

        var validationResult = command.Validate();

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
        {
            Success = true,
            Message = "Sale item created successfully",
            Data = _mapper.Map<CreateSaleItemResponse>(response)
        });
    }
}
