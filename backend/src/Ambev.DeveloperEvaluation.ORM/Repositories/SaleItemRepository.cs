using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleItemRepository using Entity Framework Core
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleItemRepository
    /// </summary>
    /// <param name="defaultContext">The database context</param>
    public SaleItemRepository(DefaultContext defaultContext)
    {
        _context = defaultContext;
    }

    /// <summary>
    /// Creates a new sale item in the repository
    /// </summary>
    /// <param name="saleItem">The sale item to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The create sale item</returns>
    public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        _context.SaleItems.Add(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return saleItem;
    }

    /// <summary>
    /// Retrieves a sale item by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, null otherwise</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .FirstOrDefaultAsync(si => si.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a sale item by its unique identifier, including the associated sale details
    /// </summary>
    /// <param name="id">The uunique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, including its associated sale details</returns>
    public async Task<SaleItem?> GetByIdWithSaleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .Include(si => si.Sale)
            .FirstOrDefaultAsync(si => si.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves all sale items associated with a specific sale by its unique identifier
    /// </summary>
    /// <param name="saleId">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of sale items</returns>
    public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .Where(si => si.SaleId == saleId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a sale item from the repository by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale item was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var saleItem = await GetByIdAsync(id, cancellationToken);
        if (saleItem == null)
            return false;

        _context.SaleItems.Remove(saleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Deletes all sale items associated with a specific sale by its unique identifier
    /// </summary>
    /// <param name="saleId">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale items was deleted, false if not found any sale item</returns>
    public async Task<bool> DeleteBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default)
    {
        var saleItems = await GetBySaleIdAsync(saleId, cancellationToken);
        if (!saleItems.Any())
            return false;
        _context.SaleItems.RemoveRange(saleItems);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing sale item in the repository
    /// </summary>
    /// <param name="saleItem">The sale item to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale item was updated, false if not found</returns>
    public async Task<bool> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
    {
        var exists = await _context.SaleItems
            .AnyAsync(si => si.Id == saleItem.Id, cancellationToken);

        if (!exists)
            return false;

        _context.SaleItems.Attach(saleItem);
        _context.Entry(saleItem).State = EntityState.Modified;

        var updated = await _context.SaveChangesAsync(cancellationToken);
        return updated > 0;
    }


}
