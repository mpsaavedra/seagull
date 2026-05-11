using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateStandSaleProduct : IMap<StandSaleProduct>
{
    public string StandSaleId { get; set; }
    public string StandProducId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public string CostId { get; set; }
    public decimal Price { get; set; } = 0.0m;
}
public sealed record UpdateStandSaleProduct : IMap<StandSaleProduct>
{
    public string Id { get; set; }
    public string StandSaleId { get; set; }
    public string StandProducId { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public string CostId { get; set; }
    public decimal Price { get; set; } = 0.0m;
}
public sealed record DeleteStandSaleProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}