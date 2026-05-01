using System;
using Pos.Domain.MeasureUnits;
using Pos.Domain.Moneys;
using Pos.Domain.Products;
using Seagull.Data;

namespace Pos.Domain.Invoices;

public partial class InvoiceProduct : AuditableEntity
{
    protected InvoiceProduct()
    {
        Quantity = 0.0m;
    }
    public InvoiceProduct(string productId, string invoiceId, Money cost, string measureUnitId, 
        decimal quantity, string? description = null)
    {
        ProductId = productId;
        InvoiceId = invoiceId;
        Cost = cost;
        MeasureUnitId = measureUnitId;
        Quantity = quantity;
        Description = description;
    }

    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; }
    public string CostId { get; set; }
    public Money Cost { get; set; }
    public string MeasureUnitId { get; set; }
    public virtual MeasureUnit MeasureUnit { get; set; }
    public decimal Quantity { get; set; }
    public string?  Description { get; set; }

    public static InvoiceProduct Create(string productId, string providerId, Money cost, string measureUnitId, 
        decimal quantity, string? description = null) =>
        new(productId, providerId, cost, measureUnitId, quantity, description);
}
