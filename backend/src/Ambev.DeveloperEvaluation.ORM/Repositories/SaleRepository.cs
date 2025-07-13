using Ambev.DeveloperEvaluation.Domain.Entities;
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
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
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

