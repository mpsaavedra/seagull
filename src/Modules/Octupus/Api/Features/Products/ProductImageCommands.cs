using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreateProductImage : IMap<ProductImage>
{
    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public string ProductId { get; set; }
    public string? Alt { get; set; }
}
public sealed record UpdateProductImage : IMap<ProductImage>
{
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public string ProductId { get; set; }
    public string? Alt { get; set; }
}
public sealed record DeleteProductImage
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}