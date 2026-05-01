using Seagull.Data;
using Pos.Domain.Purchases;
using Pos.Domain.Products;

namespace Pos.Domain.Invoices;

public partial class PurchaseInvoice : AuditableEntity 
{
  public PurchaseInvoice()
  {
      Products = [];
  }

  public string PurchaseId { get; set; }
  public virtual Purchase Purchase { get; set; }

  public string Number { get; set; }
  public DateTime Date { get; set; }
  public ICollection<PurchaseInvoiceProduct> Products { get; set; }
}
