using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Get the unique identifier for the sale.
        /// Must be a valid GUID.
        /// </summary>
        public string SaleNumber { get; private set; }
        /// <summary>
        /// Gets the date of the sale.
        /// Must be a valid date and time.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets the unique identifier for the customer associated with the sale.
        /// </summary>
        public Guid CustomerId { get; private set; }
        /// <summary>
        /// Gets the name of the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; private set; }
        /// <summary>
        /// Gets the unique identifier for the branch where the sale was made.
        /// </summary>
        public Guid BranchId { get; private set; }
        /// <summary>
        /// Gets the name of the branch where the sale was made.
        /// </summary>
        public string BranchName { get; private set; }
        /// <summary>
        /// Gets a value indicating whether the sale has been cancelled.
        /// </summary>
        public bool IsCancelled { get; private set; }
        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// Gets the date and time when the sale was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets the collection of items in the sale.
        /// </summary>
        public virtual List<SaleItem> Items { get; set; } = new();
        /// <summary>
        /// Gets the total amount of the sale, which is the sum of all item totals.
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Private constructor for Entity Framework.
        /// </summary>
        private Sale() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class with the specified parameters.
        /// </summary>
        /// <param name="saleNumber">Sale number</param>
        /// <param name="date">Date of the sale</param>
        /// <param name="curstomerId">Custotmer identifier</param>
        /// <param name="customerName">Customer name</param>
        /// <param name="branchId">Branch identifier</param>
        /// <param name="branchName">Branch name</param>
        public Sale(string saleNumber, DateTime date, Guid curstomerId, string customerName, Guid branchId, string branchName)
        {
            if (string.IsNullOrWhiteSpace(saleNumber))
                throw new ArgumentException("Sale number cannot be null or empty.", nameof(saleNumber));
            if (date == default)
                throw new ArgumentException("Date must be a valid date.", nameof(date));
            if (curstomerId == Guid.Empty)
                throw new ArgumentException("Customer ID cannot be empty.", nameof(curstomerId));
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));
            if (branchId == Guid.Empty)
                throw new ArgumentException("Branch ID cannot be empty.", nameof(branchId));
            if (string.IsNullOrWhiteSpace(branchName))
                throw new ArgumentException("Branch name cannot be null or empty.", nameof(branchName));

            SaleNumber = saleNumber;
            Date = date;
            CustomerId = curstomerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            IsCancelled = false;
            CreatedAt = DateTime.UtcNow;
        }

        private decimal CalculateTotal()
        {
            return Items
                .Where(item => !item.IsCancelled)
                .Sum(item => item.Total);
        }

        /// <summary>
        /// Adds an item to the sale.
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="productName">Product name</param>
        /// <param name="quantity">Product quantity</param>
        /// <param name="unitPrice">Product unit price</param>
        public void AddItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            var item = new SaleItem(productId, productName, quantity, unitPrice);
            AddItem(item);
        }

        public void AddItem(SaleItem saleItem)
        {
            if (saleItem == null)
                throw new ArgumentNullException(nameof(saleItem), "Sale item cannot be null.");

            Items.Add(saleItem);
            TotalAmount = CalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }


        /// <summary>
        /// Cancels the sale and all its items.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
            foreach (var item in Items)
                item.Cancel();

            RecalculateTotal();
        }

        /// <summary>
        /// Recalculates the total amount of the sale based on its items.
        /// </summary>
        public void RecalculateTotal()
        {
            TotalAmount = CalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Recalculates the sale's status based on its items.
        /// </summary>
        public void Recalculate()
        {
            if (Items.All(x => x.IsCancelled))
                IsCancelled = true;

            RecalculateTotal();
        }


        /// <summary>
        /// Updates the sale with new details.
        /// </summary>
        /// <param name="saleNumber">
        /// Sale number for the new sale.
        /// </param>
        /// <param name="date">
        /// Date of the sale.
        /// </param>
        /// <param name="customerId">Customer identifier for the sale.</param>
        /// <param name="customerName">Customer name for the sale.</param>
        /// <param name="branchId">Branch identifier for the sale</param>
        /// <param name="branchName">Branch name for the sale.</param>
        /// <exception cref="ArgumentException">This exception is thrown when any of the parameters are invalid.</exception>
        public void UpdateSale(string saleNumber, DateTime date, Guid customerId, string customerName, Guid branchId, string branchName)
        {
            if (string.IsNullOrWhiteSpace(saleNumber))
                throw new ArgumentException("Sale number cannot be null or empty.", nameof(saleNumber));
            if (date == default)
                throw new ArgumentException("Date must be a valid date.", nameof(date));
            if (customerId == Guid.Empty)
                throw new ArgumentException("Customer ID cannot be empty.", nameof(customerId));
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));
            if (branchId == Guid.Empty)
                throw new ArgumentException("Branch ID cannot be empty.", nameof(branchId));
            if (string.IsNullOrWhiteSpace(branchName))
                throw new ArgumentException("Branch name cannot be null or empty.", nameof(branchName));

            SaleNumber = saleNumber;
            Date = date;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}
