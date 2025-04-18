using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an individual item within a sales entity
    /// </summary>
    public class SaleItem: BaseEntity
    {
        /// <summary>
        /// Identifier of the associated product.
        /// </summary>
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Discount applied to this item.
        /// </summary>
        public decimal Discount { get; set; }


        /// <summary>
        /// Total price for the item, factoring in quantity and discount.
        /// </summary>
        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

        /// <summary>
        /// Applies a discount based on the quantity purchased.
        /// Throws an exception if quantity exceeds business rules.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when attempting to sell more than 20 of the same item.
        /// </exception>
        public void ApplyDiscount()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("You can't sell more than 20 identical items.");

            if (Quantity >= 10)
                Discount = (UnitPrice * Quantity) * 0.20m;
            else if (Quantity >= 4)
                Discount = (UnitPrice * Quantity) * 0.10m;
            else
                Discount = 0;
        }


    }
}
