using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sales entity
    /// </summary>
    public class Sale: BaseEntity
    {

        /// <summary>
        /// Unique reference number for the sale.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the customer who made the purchase.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// Name of the customer.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the branch where the sale took place.
        /// </summary>
        public string BranchId { get; set; } = string.Empty;

        /// <summary>
        /// Name of the branch.
        /// </summary>
        public string BranchName { get; set; } = string.Empty;

        /// <summary>
        /// Date and time of the sale.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Indicates whether the sale has been canceled.
        /// </summary>
        public bool IsCanceled { get; set; }

        /// <summary>
        /// List of items included in the sale.
        /// </summary>
        public List<SaleItem> Items { get; set; } = new();

        /// <summary>
        /// Total amount of the sale after applying discounts to all items.
        /// </summary>
        public decimal TotalAmount => Items.Sum(i => i.TotalPrice);


        /// <summary>
        /// Adds a new item to the sale and applies business rule discounts.
        /// </summary>
        /// <param name="item">The item to be added to the sale.</param>
        public void AddItem(SaleItem item)
        {
            item.ApplyDiscount();
            Items.Add(item);
        }

        ///summary
        ///Mock a Message Broker. Publish event
        ///</summary>
        /// <param name="eventName">The name of the event to be logged.</param>
        public async Task PublishEventAsync(string eventName)
        {
            // Simulates asynchronous sending operation to the broker
            await Task.Delay(10);
            Console.WriteLine($"[EVENT] {eventName} - Sale ID {Id}");
        }

    }
}
