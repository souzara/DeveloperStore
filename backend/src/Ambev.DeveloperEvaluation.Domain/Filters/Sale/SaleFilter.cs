namespace Ambev.DeveloperEvaluation.Domain.Filters.Sale;
/// <summary>
/// Represents a filter for querying sales in the system.
/// </summary>
public class SaleFilter
{
    /// <summary>
    /// Gets or sets the list of sale identifiers to filter by. If empty, all sales will be considered.
    /// </summary>
    public IEnumerable<Guid> SaleIds { get; private set; }
    /// <summary>
    /// Gets or sets the sale number to filter by. If null, it will not filter by sale number.
    /// </summary>
    public string? SaleNumber { get; private set; }

    /// <summary>
    /// Gets or sets the branch identifier to filter by. If null, it will not filter by branch.
    /// </summary>
    public Guid? BranchId { get; private set; }

    /// <summary>
    /// Gets or sets the branch name to filter by. If null, it will not filter by branch name.
    /// </summary>
    public string? BranchName { get; private set; }

    /// <summary>
    /// Gets or sets the customer identifier to filter by. If null, it will not filter by customer.
    /// </summary>
    public Guid? CustomerId { get; private set; }

    /// <summary>
    /// Gets or sets the customer name to filter by. If null, it will not filter by customer name.
    /// </summary>
    public string? CustomerName { get; private set; }

    /// <summary>
    /// Gets or sets the from date to filter sales. If null, it will not filter by date range.
    /// </summary>
    public DateTime? FromDate { get; private set; }
    /// <summary>
    /// Gets or sets the to date to filter sales. If null, it will not filter by date range.
    /// </summary>
    public DateTime? ToDate { get; private set; }
    /// <summary>
    /// Gets or sets a flag indicating whether to filter by cancelled sales.
    /// </summary>
    public bool? IsCancelled { get; private set; }

    /// <summary>
    /// Gets or sets a flag indicating whether to include items in the sale details.
    /// </summary>
    public bool IncludeItems { get; }

    /// <summary>
    /// Gets or sets the page number for pagination. Defaults to 1.
    /// </summary>
    public int Page { get; private set; }
    /// <summary>
    /// Gets or sets the page size for pagination. Defaults to 20.
    /// </summary>
    public int PageSize { get; private set; }

    /// <summary>
    /// Initializes a new instance of the SaleFilter class with the specified parameters.
    /// </summary>
    /// <param name="saleIds">List of sale identifiers to filter by. If empty, all sales will be considered.</param>
    /// <param name="saleNumber">Sale number to filter by. If null, it will not filter by sale number.</param>
    /// <param name="customerId">Customer identifier to filter by. If null, it will not filter by customer.</param>
    /// <param name="fromDate">From date to filter sales. If null, it will not filter by date range.</param>
    /// <param name="toDate">To date to filter sales. If null, it will not filter by date range.</param>
    /// <param name="isCancelled">Flag indicating whether to filter by cancelled sales.</param>
    /// <param name="page">Page number for pagination. Defaults to 1.</param>
    /// <param name="pageSize">Page size for pagination. Defaults to 20.</param>
    public SaleFilter(IEnumerable<Guid> saleIds,
                      string? saleNumber,
                      Guid? branchId,
                      string? branchName,
                      Guid? customerId,
                      string? customerName,
                      DateTime? fromDate,
                      DateTime? toDate,
                      bool? isCancelled,
                      bool? includeItems,
                      int page,
                      int pageSize)
    {
        SaleIds = saleIds;
        SaleNumber = saleNumber;
        BranchId = branchId;
        BranchName = branchName;
        CustomerId = customerId;
        CustomerName = customerName;
        FromDate = fromDate;
        ToDate = toDate;
        IsCancelled = isCancelled;
        IncludeItems = includeItems ?? false;
        Page = page;
        PageSize = pageSize;
    }
}
