using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }

    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
    public bool IsCanceled { get; set; }

    public List<GetSaleItemDto> Items { get; set; } = new();
}
