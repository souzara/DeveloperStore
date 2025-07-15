using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Filters.Sale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="defaultContext">The database context</param>
    public SaleRepository(DefaultContext defaultContext)
    {
        _context = defaultContext;
    }

    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    /// <summary>
    /// Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, null otherwise</returns>
    public Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Sales
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }


    /// <summary>
    /// Retrieves a sale by its unique identifier along with its items
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale with its items if found, null otherwise.</returns>
    public Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _context.Sales
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of sales based on the provided filter criteria
    /// </summary>
    /// <param name="saleFilter">Sale filter</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated result containing a list of sales that match the filter criteria.</returns>
    public async Task<PaginatedData<Sale>> ListAsync(SaleFilter saleFilter, CancellationToken cancellationToken = default)
    {
        var query = _context.Sales.AsQueryable();

        if (saleFilter.SaleIds?.Any() == true)
            query = query.Where(s => saleFilter.SaleIds.Contains(s.Id));
        if (!string.IsNullOrWhiteSpace(saleFilter.SaleNumber))
            query = query.Where(s => s.SaleNumber == saleFilter.SaleNumber);
        if (saleFilter.BranchId.HasValue)
            query = query.Where(s => s.BranchId == saleFilter.BranchId.Value);
        if (!string.IsNullOrWhiteSpace(saleFilter.BranchName))
            query = query.Where(s => s.BranchName.StartsWith(saleFilter.BranchName));
        if (saleFilter.CustomerId.HasValue)
            query = query.Where(s => s.CustomerId == saleFilter.CustomerId.Value);
        if (!string.IsNullOrWhiteSpace(saleFilter.CustomerName))
            query = query.Where(s => s.CustomerName.StartsWith(saleFilter.CustomerName));
        if (saleFilter.FromDate.HasValue)
            query = query.Where(s => s.Date >= saleFilter.FromDate.Value);
        if (saleFilter.ToDate.HasValue)
            query = query.Where(s => s.Date <= saleFilter.ToDate.Value);
        if (saleFilter.IsCancelled.HasValue)
            query = query.Where(s => s.IsCancelled == saleFilter.IsCancelled.Value);
        if (saleFilter.IncludeItems)
            query = query.Include(s => s.Items);

        var totalCount = await query.CountAsync(cancellationToken);

        var sales = await query
            .OrderByDescending(s => s.CreatedAt)
            .Skip((saleFilter.Page - 1) * saleFilter.PageSize)
            .Take(saleFilter.PageSize)
            .ToListAsync(cancellationToken);
        return new PaginatedData<Sale>(sales, saleFilter.Page, saleFilter.PageSize, totalCount);
    }


    /// <summary>
    /// Retrieves all sales associated with a specific customer by their unique identifier
    /// </summary>
    /// <param name="customerId">The customer identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sales list for a specific customer</returns>
    public async Task<IEnumerable<Sale>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Where(s => s.CustomerId == customerId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves all sales associated with a specific branch by its unique identifier
    /// </summary>
    /// <param name="branchId">The branch identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sales list for a specific branch</returns>
    public async Task<IEnumerable<Sale>> GetByBranchIdAsync(Guid branchId, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Where(s => s.BranchId == branchId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a sale by its unique identifier
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale was deleted, null if not foud</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing sale in the repository
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale was updated, false otherwise</returns>
    public async Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var exists = await _context.Sales
            .AnyAsync(s => s.Id == sale.Id, cancellationToken);
        if (!exists)
            return false;

        _context.Sales.Attach(sale);
        _context.Entry(sale).State = EntityState.Modified;
        var updated = await _context.SaveChangesAsync(cancellationToken);

        return updated > 0;
    }


}

