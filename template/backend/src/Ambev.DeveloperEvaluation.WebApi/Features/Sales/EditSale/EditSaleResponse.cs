﻿using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.EditSale
{
    /// <summary>
    /// API response model for EditSale operation
    /// </summary>
    public class EditSaleResponse
    {
        /// <summary>
         /// Unique identifier of the Edit sale.
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
        /// Name of the customer who made the purchase.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Name of the branch where the sale occurred.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Total amount of the sale, including all items and applicable charges.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Indicates whether the sale has been canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// List of items included in the sale.
        /// </summary>
        public List<EditSaleItemResponse> Items { get; set; } = new();
    }
}
