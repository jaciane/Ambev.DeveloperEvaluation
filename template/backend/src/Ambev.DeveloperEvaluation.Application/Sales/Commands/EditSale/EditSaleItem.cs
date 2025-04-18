
namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Represents a product item in the EditSaleCommand.
    /// </summary>
    public class EditSaleItem
    {
        /// <summary>
        /// The unique identifier of the sale item
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product sold.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item.
        /// </summary>
        public decimal Discount { get; set; }

    }
}
