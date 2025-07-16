using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an item in a sale.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier for the product associated with the sale item.
        /// </summary>
        public Guid ProductId { get; private set; }
        /// <summary>
        /// Gets the name of the product associated with the sale item.
        /// </summary>
        public string ProductName { get; private set; }
        /// <summary>
        /// Gets the quantity of the product in the sale item.
        /// </summary>
        public int Quantity { get; private set; }
        /// <summary>
        /// Gets the unit price of the product in the sale item.
        /// </summary>
        public decimal UnitPrice { get; private set; }
        /// <summary>
        /// Gets the discount applied to the sale item based on quantity and unit price.
        /// </summary>
        public decimal Discount { get; private set; }
        /// <summary>
        /// Calculates the total price for the sale item after applying the discount.
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the sale item has been cancelled.
        /// </summary>
        public bool IsCancelled { get; private set; }

        /// <summary>
        /// Gets the date and time when the sale item was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets the date and time when the sale item was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }


        /// <summary>
        /// Gets the the sale associated with this sale item.
        /// </summary>
        public virtual Sale Sale { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the sale associated with this sale item.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Private constructor for Entity Framework.
        /// </summary>
        private SaleItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleItem"/> class with the specified parameters.
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="productName">Product name</param>
        /// <param name="quantity">Product quantity</param>
        /// <param name="unitPrice">Product unit price</param>
        public SaleItem(Guid productId, string productName, int quantity, decimal unitPrice)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException("ProductId cannot be empty.", nameof(productId));
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("ProductName cannot be empty or whitespace.", nameof(productName));
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            if (quantity > 20)
                throw new ArgumentException("Quantity cannot exceed 20.", nameof(quantity));
            if (unitPrice <= 0)
                throw new ArgumentException("UnitPrice must be greater than zero.", nameof(unitPrice));

            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = CalculateDiscount(quantity, unitPrice);
            Total = CalculateTotal();
            IsCancelled = false;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Calculates the discount based on the quantity and unit price.
        /// </summary>
        /// <param name="quantity">Product quantity</param>
        /// <param name="price">Product unit price</param>
        /// <returns></returns>
        private decimal CalculateDiscount(int quantity, decimal price)
        {
            if (quantity >= 10)
                return quantity * price * 0.20m;
            if (quantity >= 4)
                return quantity * price * 0.10m;
            return 0;
        }

        private decimal CalculateTotal()
        {
            return (Quantity * UnitPrice) - Discount;
        }

        /// <summary>
        /// Cancels the sale item, marking it as cancelled and setting the discount to zero.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }

    }
}
