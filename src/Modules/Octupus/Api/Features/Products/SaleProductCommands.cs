using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateSaleProduct : IMap<SaleProduct>
{
    public string ProductId { get; set; }
    public string SaleId { get; set; }
    public string WarehouseId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal SalePrice { get; set; } = 0.0m;
    public string? Details { get; set; }
}
public sealed record UpdateSaleProduct : IMap<SaleProduct>
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string SaleId { get; set; }
    public string WarehouseId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal SalePrice { get; set; } = 0.0m;
    public string? Details { get; set; }
}
public sealed record DeleteSaleProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}