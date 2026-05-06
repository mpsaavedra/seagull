using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record SaleProductDto : DtoBase
{
    public ProductDto Product { get; set; }
    public SaleDto Sale { get; set; }
    public WarehouseDto Warehouse { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal SalePrice { get; set; } = 0.0m;
    public MoneyDto SaleCost { get; set; }
    public string? Details { get; set; }
}
