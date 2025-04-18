using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.EditSale
{
    /// <summary>
    /// Represents the data required to edit an existing sale.
    /// </summary>
    public class EditSaleRequest
    {
        /// <summary>
        /// The ID of the Id associated with the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Identifier of the customer making the purchase.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer making the purchase.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the branch where the sale is made.
        /// </summary>
        public string BranchId { get; set; } = string.Empty;

        /// <summary>
        /// Name of the branch where the sale is made.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// List of items included in the sale request.
        /// </summary>
        public List<EditSaleItemRequest> Items { get; set; } = new();
    }

}
