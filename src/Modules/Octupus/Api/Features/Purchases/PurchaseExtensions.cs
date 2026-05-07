using System;
using Octupus.Api.Features.Warehouses;

namespace Octupus.Api.Features.Purchases;

public partial class Purchase
{
    public static Purchase Create(string number, DateTime date, string WarehouseId,
        decimal? totalPrice = null, decimal? subTotal = null, DateTime? dueDate = null,
        decimal? tax = null, decimal? discount = null, decimal? shippingCost = null,
        string? shippingId = null) =>
        new()
        {
            Number = number,
            WarehouseId = WarehouseId,
            Date = date,
            DueDate = dueDate,
            Discount = discount,
            TotalPrice = totalPrice.HasValue ? totalPrice.Value : 0.0m,
            SubTotal = subTotal.HasValue ? subTotal.Value : 0.0m,
            ShippingCost = shippingCost,
            ShippingId = shippingId
        };
}
