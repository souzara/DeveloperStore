﻿using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Filters.Sale;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by its unique identifier along with its items
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale with its items if found, null otherwise.</returns>
    Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a paginated list of sales based on the provided filter criteria
    /// </summary>
    /// <param name="saleFilter">Sale filter</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Paginated result containing a list of sales that match the filter criteria.</returns>
    Task<PaginatedData<Sale>> ListAsync(SaleFilter saleFilter, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all sales associated with a specific customer by their unique identifier
    /// </summary>
    /// <param name="customerId">The customer identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sales list for a specific customer</returns>
    Task<IEnumerable<Sale>> GetByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all sales associated with a specific branch by its unique identifier
    /// </summary>
    /// <param name="branchId">The branch identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sales list for a specific branch</returns>
    Task<IEnumerable<Sale>> GetByBranchIdAsync(Guid branchId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sale by its unique identifier
    /// </summary>
    /// <param name="id">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale was deleted, null if not foud</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sale in the repository
    /// </summary>
    /// <param name="sale">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale was updated, false otherwise</returns>
    Task<bool> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
}
