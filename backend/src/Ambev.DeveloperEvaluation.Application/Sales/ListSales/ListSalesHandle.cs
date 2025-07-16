using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Filters.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Handler for processing ListSaleCommand requests
/// </summary>
public class ListSalesHandle : IRequestHandler<ListSalesCommand, PaginatedResult<GetSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the ListSaleHandle class
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ListSalesHandle(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListSaleCommand to retrieve a paginated list of sales
    /// </summary>
    /// <param name="request">The ListSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the ListSale operation, which contains a paginated list of sales.</returns>
    public async Task<PaginatedResult<GetSaleResult>> Handle(ListSalesCommand request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var salesFilter = _mapper.Map<SaleFilter>(request);

        var sales = await _saleRepository.ListAsync(salesFilter, cancellationToken);

        return _mapper.Map<PaginatedResult<GetSaleResult>>(sales);

    }
}
