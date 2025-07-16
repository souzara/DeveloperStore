namespace Ambev.DeveloperEvaluation.Domain.Common
{
    /// <summary>
    /// Represents a paginated result set for a collection of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the paginated result.</typeparam>
    public class PaginatedData<T>
    {
        public IReadOnlyList<T> Items { get; }
        /// <summary>
        /// The current page number (1-based index).
        /// </summary>
        public int Page { get; }
        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; }
        /// <summary>
        /// The total number of items across all pages.
        /// </summary>
        public int TotalItems { get; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedData{T}"/> class.
        /// </summary>
        /// <param name="items">The items in the current page.</param>
        /// <param name="page">Current page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalItems">Total of items</param>
        public PaginatedData(IReadOnlyList<T> items, int page, int pageSize, int totalItems)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
