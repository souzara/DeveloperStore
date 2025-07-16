using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem;

/// <summary>
/// Handler for processing CreateSaleItemCommand requests
/// </summary>
public class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleItemHandler
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public CreateSaleItemHandler(ISaleItemRepository saleItemRepository, ISaleRepository saleRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleItemCommand to create a new sale item in the repository
    /// </summary>
    /// <param name="request">The CreateSaleItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale item details.</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdWithItemsAsync(request.SaleId, cancellationToken);

        if (sale == null)
            throw new ValidationException($"Sale with ID {request.SaleId} does not exist.");

        if (sale.IsCancelled)
            throw new ValidationException($"Sale with ID {request.SaleId} is cancelled and cannot have new items added.");

        var saleItem = _mapper.Map<Domain.Entities.SaleItem>(request);

        sale.AddItem(saleItem);

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return new CreateSaleItemResult
        {
            Id = saleItem.Id
        };
    }
}