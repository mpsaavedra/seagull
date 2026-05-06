using System;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Invoices;

public partial class PurchaseInvoice : AuditableEntity, IMap<PurchaseInvoiceDto>
{
  public string PurchaseId { get; set; }
  public virtual Purchase Purchase { get; set; }

  public string Number { get; set; }
  public DateTime Date { get; set; } = DateTime.UtcNow;
  public ICollection<PurchaseInvoiceProduct> Products { get; set; } = [];
}
