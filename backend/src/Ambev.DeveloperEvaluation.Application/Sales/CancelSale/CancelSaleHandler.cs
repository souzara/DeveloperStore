﻿using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Handle for canceling a sale.
/// </summary>
public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IEventBusService _eventBusService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CancelSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CancelSaleHandler(ISaleRepository saleRepository, IEventBusService eventBusService, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _eventBusService = eventBusService;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the cancellation of a sale by its unique identifier.
    /// </summary>
    /// <param name="request">The CancelSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns> True if the sale was successfully canceled, false if not found.</returns>
    public async Task<bool> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdWithItemsAsync(command.Id, cancellationToken);

        if (sale == null)
            return false;

        sale.Cancel();

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        var saleCancelledEvent = _mapper.Map<SaleCancelledEvent>(sale);

        await _eventBusService.PublishAsync(saleCancelledEvent);

        return true;
    }
}
