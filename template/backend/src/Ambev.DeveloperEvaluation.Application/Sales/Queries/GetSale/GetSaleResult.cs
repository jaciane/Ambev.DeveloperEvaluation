using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    /// <summary>
    /// Represents the result of a sale returned in a query result.
    /// </summary>
    public class GetSaleResult
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Reference number of the sale (e.g., invoice or order number).
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Date and time when the sale was made.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Name of the customer associated with the sale.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Name of the branch where the sale was recorded.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Total value of the sale including all items.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale has been canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// List of items included in the sale.
        /// </summary>
        public List<GetSaleItemResult> Items { get; set; } = new();
    }
}
