using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateWarehouseProduct : IMap<WarehouseProduct>
{
    public string ProductId { get; set; }
    public string WarehouseId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal? ReOrderLevel { get; set; } = -1;
}
public sealed record UpdateWarehouseProduct : IMap<WarehouseProduct>
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string WarehouseId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal? ReOrderLevel { get; set; } = -1;
}
public sealed record DeleteWarehouseProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}