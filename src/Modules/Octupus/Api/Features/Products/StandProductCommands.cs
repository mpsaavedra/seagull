using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateStandProduct : IMap<StandProduct>
{
    public string StandId { get; set; }
    public string ProductId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal Price { get; set; } = 0.0m;
    public string CostId { get; set; }
    public decimal? ReOrderLevel { get; set; } = -1;
    public string WarehouseId { get; set; }
}
public sealed record UpdateStandProduct : IMap<StandProduct>
{
    public string Id { get; set; }
    public string? StandId { get; set; }
    public string? ProductId { get; set; }
    public decimal? Quantity { get; set; } = 0.0m;
    public decimal? Price { get; set; } = 0.0m;
    public string? CostId { get; set; }
    public decimal? ReOrderLevel { get; set; } = -1;
    public string? WarehouseId { get; set; }
}
public sealed record DeleteStandProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}