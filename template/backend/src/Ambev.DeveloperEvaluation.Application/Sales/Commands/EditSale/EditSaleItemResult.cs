

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Represents the result of a successfully Editd sale item.
    /// </summary>
    public class EditSaleItemResult
    {
        /// <summary>
        /// The unique identifier of the sale item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the total price for the item after applying discounts.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
