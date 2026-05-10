using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Invoices;

public sealed record CreatePurchaseInvoice : IMap<PurchaseInvoice>
{
    public string PurchaseId { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
public sealed record UpdatePurchaseInvoice : IMap<PurchaseInvoice>
{
    public string Id { get; set; }
    public string? PurchaseId { get; set; }
    public string? Number { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
}
public sealed record DeletePurchaseInvoice
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}
