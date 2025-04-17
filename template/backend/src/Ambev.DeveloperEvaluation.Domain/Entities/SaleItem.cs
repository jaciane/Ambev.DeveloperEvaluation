using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem: BaseEntity
    {
        public string Id => Id.ToString();

        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool IsCanceled { get; set; }

        public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

        public void ApplyDiscount()
        {
            if (Quantity > 20)
                throw new InvalidOperationException("You can't sell more than 20 identical items.");

            if (Quantity >= 10)
                Discount = (UnitPrice * Quantity) * 0.20m;
            else if (Quantity >= 4)
                Discount = (UnitPrice * Quantity) * 0.10m;
            else
                Discount = 0;
        }

        public void Cancel()
        {
            IsCanceled = true;
            Console.WriteLine($"[EVENT] ItemCanceled - Product {ProductName}");
        }

    }
}
