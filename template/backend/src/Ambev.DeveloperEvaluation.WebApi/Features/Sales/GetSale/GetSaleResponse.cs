namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// Unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sale number used for reference.
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
    /// Total amount of the sale after discounts.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCanceled { get; set; }

    /// <summary>
    /// List of items included in the sale.
    /// </summary>
    public List<GetSaleItemResponse> Items { get; set; } = new();
}
