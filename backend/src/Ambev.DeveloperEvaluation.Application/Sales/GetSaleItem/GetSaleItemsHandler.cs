using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleItem;
/// <summary>
/// Handler for processing GetSaleItemsCommand requests
/// </summary>
public class GetSaleItemsHandler : IRequestHandler<GetSaleItemsCommand, IEnumerable<GetSaleItemResult>?>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the GetSaleItemsHandler class
    /// </summary>
    /// <param name="saleItemRepository">The sale item repository</param>
    /// <param name="mapper">The AutoMapper iinstance</param>
    public GetSaleItemsHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleItemsCommand to retrieve sale items for a specific sale
    /// </summary>
    /// <param name="request">The GetSaleItemsCommand</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>
    /// The result of the GetSaleItems operation, which contains a list of 
    /// sale items if found, null if not found any sale item.
    /// </returns>
    public async Task<IEnumerable<GetSaleItemResult>?> Handle(GetSaleItemsCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleItems = await _saleItemRepository.GetBySaleIdAsync(request.SaleId, cancellationToken);

        if (saleItems == null || !saleItems.Any())
            return null;

        return _mapper.Map<IEnumerable<GetSaleItemResult>>(saleItems);
    }
}
