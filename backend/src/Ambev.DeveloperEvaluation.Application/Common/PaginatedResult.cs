namespace Ambev.DeveloperEvaluation.Application.Common
{
    /// <summary>
    /// Represents a paginated result set for a collection of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the paginated result.</typeparam>
    public class PaginatedResult<T>
    {
        /// <summary>
        /// The current page number (1-based index).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of items across all pages.
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// The total number of pages available based on the total items and page size.
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// The list of items on the current page.
        /// </summary>
        public IReadOnlyList<T> Items { get; set; }

    }
}
