using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Invoices;

public sealed record CreateInvoice : IMap<Invoice>
{
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
}
public sealed record UpdateInvoice : IMap<Invoice>
{
    public string Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
}
public sealed record DeleteInvoice
{
    public string Id { get; set; }
    public bool SoftDelet { get; set; } = true;
}