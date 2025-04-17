using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale: BaseEntity
    {
        
        public string SaleNumber { get; set; } = string.Empty;

        public string CustomerId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public string BranchId { get; set; } = string.Empty;
        
        public string BranchName { get; set; } = string.Empty;

        public DateTime SaleDate { get; set; }
        
        public bool IsCanceled { get; set; }

        public List<SaleItem> Items { get; set; } = new();


        public decimal TotalAmount => Items.Sum(i => i.TotalPrice);

        public void AddItem(SaleItem item)
        {
            item.ApplyDiscount();
            Items.Add(item);
        }

        public void Cancel()
        {
            IsCanceled = true;
            LogEvent("SaleCanceled");
        }

        private void LogEvent(string eventName)
        {
            Console.WriteLine($"[EVENT] {eventName} - Sale {SaleNumber}");
        }

    }
}
