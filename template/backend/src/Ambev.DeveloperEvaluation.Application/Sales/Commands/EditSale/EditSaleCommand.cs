using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Command to Edit a new sale.
    /// </summary>
    public class EditSaleCommand : IRequest<EditSaleResult>
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

        public List<EditSaleItem> Items { get; set; } = new();
    }
}
