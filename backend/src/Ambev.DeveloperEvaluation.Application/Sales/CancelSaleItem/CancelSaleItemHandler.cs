using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSaleItem;

/// <summary>
/// Handler for canceling a sale item.
/// </summary>
public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, bool>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IEventBusService _eventBusService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the CancelSaleItemHandler class.
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CancelSaleItemHandler(ISaleItemRepository saleItemRepository, IEventBusService eventBusService, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _eventBusService = eventBusService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the cancellation of a sale item by its unique identifier.
    /// </summary>
    /// <param name="request">The CancelSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale item was successfully canceled, false if not found.</returns>
    public async Task<bool> Handle(CancelSaleItemCommand request, CancellationToken cancellationToken)
    {
        var saleItem = await _saleItemRepository.GetByIdWithSaleAsync(request.ItemId, cancellationToken);

        if (saleItem == null || saleItem.SaleId != request.SaleId)
            return false;

        saleItem.Cancel();

        saleItem.Sale?.Recalculate();

        await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);

        var saleItemCancelledEvent = _mapper.Map<SaleItemCancelledEvent>(saleItem);

        await _eventBusService.PublishAsync(saleItemCancelledEvent);

        return true;
    }
}
