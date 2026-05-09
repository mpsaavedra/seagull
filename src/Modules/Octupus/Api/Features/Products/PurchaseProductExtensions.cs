using System;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Purchases;
using Octupus.Api.Features.Suppliers;

namespace Octupus.Api.Features.Products;

public partial class PurchaseProduct
{
    public static PurchaseProduct Create(Product product, Purchase purchase, decimal quantity,
        Money purchasePrice, Supplier? supplier = null, DateTime? date = null, DateTime? dueDate = null,
        string? details = null) =>
        new()
        {
            Product = product,
            Purchase = purchase,
            Quantity = quantity,
            PurchasePrice = purchasePrice,
            Supplier = supplier,
            Date = date.HasValue ? date : DateTime.UtcNow,
            DueDate = dueDate,
            Details = details
        };
}
