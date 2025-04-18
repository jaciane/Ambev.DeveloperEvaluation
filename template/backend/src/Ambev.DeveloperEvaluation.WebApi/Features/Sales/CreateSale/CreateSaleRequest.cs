using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Represents the request model for creating a sale.
    /// </summary>
    public class CreateSaleRequest
    {
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
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }
}
