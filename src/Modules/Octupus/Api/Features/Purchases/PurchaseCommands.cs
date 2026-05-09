using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Purchases;

public sealed record CreatePurchase : IMap<Purchase>
{
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
}
public sealed record UpdatePurchase : IMap<Purchase>
{
    public string Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
}
public sealed record DeletePurchase
{
    public string Id { get; set; }
    public bool SoftDelet { get; set; } = true;
}
