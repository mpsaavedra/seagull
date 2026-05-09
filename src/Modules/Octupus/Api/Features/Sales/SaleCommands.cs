using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Sales;

public sealed record CreateSale : IMap<Sale>
{
    public string WarehouseId { get; set; }
    public string? CustomerId { get; set; }
    public string Number { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? ShippingCost { get; set; }
    public string? ShippingId { get; set; }
}
public sealed record UpdateSale : IMap<Sale>
{
    public string Id { get; set; }
    public string WarehouseId { get; set; }
    public string? CustomerId { get; set; }
    public string Number { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? ShippingCost { get; set; }
    public string? ShippingId { get; set; }
}
public sealed record DeleteSale
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}
