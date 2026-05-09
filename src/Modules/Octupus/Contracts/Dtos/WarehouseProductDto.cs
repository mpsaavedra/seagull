using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record WarehouseProductDto : DtoBase
{
    public ProductDto Product { get; set; }
    public WarehouseDto Warehouse { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal? ReOrderLevel { get; set; } = -1;
}


public sealed record WarehouseProductListDto : DtoBase
{
    public ProductListDto Product { get; set; }
    public WarehouseListDto Warehouse { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal? ReOrderLevel { get; set; } = -1;
}