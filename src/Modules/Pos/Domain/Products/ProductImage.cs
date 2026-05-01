using System;
using Seagull.Data;

namespace Pos.Domain.Products;

public partial class ProductImage : AuditableEntity
{
    protected ProductImage() : base()
    {
    }
    public ProductImage(string imageUrl, string productId, int? order, string? alt = null)
    {
        ImageUrl = imageUrl;
        ProductId = productId;
        Order = order;
        Alt = alt;
    }

    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public string ProductId{ get; set; }
    public virtual Product Product { get; set; }
    public string? Alt { get; set; }

    public static ProductImage Create(string imageUrl, string productId, int? order, string? alt = null) =>
        new(imageUrl, productId, order, alt);
}
