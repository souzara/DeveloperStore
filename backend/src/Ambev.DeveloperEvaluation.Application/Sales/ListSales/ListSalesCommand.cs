using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Common;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Represents a filter for querying sales in the system.
/// </summary>
public class ListSalesCommand : IRequest<PaginatedResult<GetSaleResult>>
{
    /// <summary>
    /// Gets or sets the list of sale identifiers to filter by. If empty, all sales will be considered.
    /// </summary>
    public IEnumerable<Guid> SaleIds { get; set; }
    /// <summary>
    /// Gets or sets the sale number to filter by. If null, it will not filter by sale number.
    /// </summary>
    public string? SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the branch identifier to filter by. If null, it will not filter by branch.
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Gets or sets the branch name to filter by. If null, it will not filter by branch name.
    /// </summary>
    public string? BranchName { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier to filter by. If null, it will not filter by customer.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the customer name to filter by. If null, it will not filter by customer name.
    /// </summary>
    public string? CustomerName { get; set; }

    /// <summary>
    /// Gets or sets the from date to filter sales. If null, it will not filter by date range.
    /// </summary>
    public DateTime? FromDate { get; set; }
    /// <summary>
    /// Gets or sets the to date to filter sales. If null, it will not filter by date range.
    /// </summary>
    public DateTime? ToDate { get; set; }
    /// <summary>
    /// Gets or sets a flag indicating whether to filter by cancelled sales.
    /// </summary>
    public bool? IsCancelled { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether to include items in the sale details.
    /// </summary>
    public bool IncludeItems { get; set; }

    /// <summary>
    /// Gets or sets the page number for pagination. Defaults to 1.
    /// </summary>
    public int Page { get; set; } = 1;
    /// <summary>
    /// Gets or sets the page size for pagination. Defaults to 20.
    /// </summary>
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// Validates the current instance of <see cref="ListSalesCommand"/> using the <see cref="ListSalesValidator"/>.
    /// </summary>
    /// <returns>
    /// ValidationResult containing the validation status and any errors encountered during validation.
    /// </returns>
    public ValidationResult Validate()
    {
        var validator = new ListSalesValidator();
        return validator.Validate(this);
    }
}
