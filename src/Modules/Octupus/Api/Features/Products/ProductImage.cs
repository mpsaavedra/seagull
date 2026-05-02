using System;
using Seagull.Data;

namespace Octupus.Api.Features.Products;

public partial class ProductImage : AuditableEntity
{

    public string ImageUrl { get; set; }
    public int? Order { get; set; } = -1;
    public string ProductId{ get; set; }
    public virtual Product Product { get; set; }
    public string? Alt { get; set; }

    public static ProductImage Create(string imageUrl, string productId, int? order, string? alt = null) =>
        new()
        {
            ImageUrl = imageUrl,
            ProductId = productId,
            Order = order,
            Alt = alt
        };
}
