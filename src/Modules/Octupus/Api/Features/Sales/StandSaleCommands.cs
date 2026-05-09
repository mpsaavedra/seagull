using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Sales;

public sealed record CreateStandSale : IMap<StandSale>
{
    public string StandId { get; set; }
    public string Number { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
}
public sealed record UpdateStandSale : IMap<StandSale>
{
    public string Id { get; set; }
    public string? StandId { get; set; }
    public string? Number { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal? TotalPrice { get; set; } = 0.0m;
    public decimal? SubTotal { get; set; } = 0.0m;
}
public sealed record DeleteStandSale
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}