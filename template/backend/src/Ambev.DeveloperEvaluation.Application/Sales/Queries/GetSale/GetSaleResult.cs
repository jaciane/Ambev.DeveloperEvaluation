using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    public class GetSaleResult
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
        public bool IsCanceled { get; set; }

        public List<GetSaleItemDto> Items { get; set; } = new();
    }
}
