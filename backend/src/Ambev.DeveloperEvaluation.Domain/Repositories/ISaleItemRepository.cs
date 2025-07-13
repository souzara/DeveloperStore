using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for SaleItem entity operations
/// </summary>
public interface ISaleItemRepository
{
    /// <summary>
    /// Creates a new sale item in the repository
    /// </summary>
    /// <param name="saleItem">The sale item to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale item</returns>
    Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale item by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale item if found, null otherwise</returns>
    Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all sale items associated with a specific sale by its unique identifier
    /// </summary>
    /// <param name="saleId">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Sale item list</returns>
    Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sale item from the repository by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale item was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes all sale items associated with a specific sale by its unique identifier
    /// </summary>
    /// <param name="saleId">Sale unique identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale items was deleted, false if not found any sale item</returns>
    Task<bool> DeleteBySaleIdAsync(Guid saleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing sale item in the repository
    /// </summary>
    /// <param name="saleItem">The sale item to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if sale item was updated, false otherwise</returns>
    Task<bool> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
}
