using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Invoices;

public sealed record CreateInvoiceProduct : IMap<InvoiceProduct>
{
    public string ProductId { get; set; }
    public string InvoiceId { get; set; }
    public string CostId { get; set; }
    public string MeasureUnitId { get; set; }
    public decimal Quantity { get; set; }
    public string? Description { get; set; }
}
public sealed record UpdateInvoiceProduct : IMap<InvoiceProduct>
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string InvoiceId { get; set; }
    public string CostId { get; set; }
    public string MeasureUnitId { get; set; }
    public decimal Quantity { get; set; }
    public string? Description { get; set; }
}
public sealed record DeleteInvoiceProduct
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}