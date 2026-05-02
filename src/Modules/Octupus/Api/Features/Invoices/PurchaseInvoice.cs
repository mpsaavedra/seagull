using System;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Seagull.Data;

namespace Octupus.Api.Features.Invoices;

public partial class PurchaseInvoice : AuditableEntity 
{
  public string PurchaseId { get; set; }
  public virtual Purchase Purchase { get; set; }

  public string Number { get; set; }
  public DateTime Date { get; set; }
  public ICollection<PurchaseInvoiceProduct> Products { get; set; } = [];
}
