using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandProductDto : DtoBase
{
    public StandDto Stand { get; set; }
    public ProductDto Product { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal Price { get; set; } = 0.0m;
    public MoneyDto Cost { get; set; }
    public decimal? ReOrderLevel { get; set; } = -1;
    public ICollection<StandSaleProductDto> StandSaleProducts { get; set; } = [];
    public WarehouseDto Warehouse { get; set; }
}


public sealed record StandProductListDto : DtoBase
{
    public StandListDto Stand { get; set; }
    public ProductListDto Product { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal Price { get; set; } = 0.0m;
    public MoneyListDto Cost { get; set; }
    public decimal? ReOrderLevel { get; set; } = -1;
    public ICollection<StandSaleProductListDto> StandSaleProducts { get; set; } = [];
    public WarehouseListDto Warehouse { get; set; }
}