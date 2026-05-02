using System;
using Octupus.Api.Features.MeasureUnits;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Products;
using Seagull.Data;

namespace Octupus.Api.Features.Invoices;

public partial class InvoiceProduct : AuditableEntity
{
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
}
