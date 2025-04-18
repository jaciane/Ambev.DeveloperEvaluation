
namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Represents the result of a successfully Editd sale.
    /// </summary>
    public class EditSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the branch where the sale occurred.
        /// </summary>
        public string BranchId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the branch where the sale occurred.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of items included in the sale.
        /// </summary>
        public List<EditSaleItemResult> Items { get; set; } = new();
    }
}
