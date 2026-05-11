using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateProduct : IMap<Product>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string SKU { get; set; }
    public string? CategoryId { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? CostId { get; set; }
    public string MeasureUnitId { get; set; }
}
public sealed record UpdateProduct : IMap<Product>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string SKU { get; set; }
    public string? CategoryId { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? CostId { get; set; }
    public string MeasureUnitId { get; set; }
}
public sealed record DeleteProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = false;
}