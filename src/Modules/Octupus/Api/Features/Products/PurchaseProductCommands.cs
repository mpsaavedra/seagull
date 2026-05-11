using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public sealed record CreatePurchaseProduct : IMap<PurchaseProduct>
{
    public string ProductId { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public string PurchaseId { get; set; }
    public decimal Quantity { get; set; }
    public string PurchasePriceId { get; set; }
    public string? Details { get; set; }
    public string? SupplierId { get; set; }
}
public sealed record UpdatePurchaseProduct : IMap<PurchaseProduct>
{
    public string Id { get; set; }
    public string? ProductId { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public string? PurchaseId { get; set; }
    public decimal? Quantity { get; set; }
    public string? PurchasePriceId { get; set; }
    public string? Details { get; set; }
    public string? SupplierId { get; set; }
}
public sealed record DeletePurchaseProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}