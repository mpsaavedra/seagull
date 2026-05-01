using Pos.Domain.Purchases;
using Pos.Domain.Warehouses;
using Pos.Domain.Invoices;
using Seagull.Data.ValueObjects;
using Pos.Domain.MeasureUnits;
using Seagull.Data;
using Pos.Domain.Moneys;

namespace Pos.Domain.Products;

public partial class PurchaseInvoiceProduct : AuditableEntity
{
    public PurchaseInvoiceProduct()
    {
      
    }

    public string PurchaseInvoiceId { get; set; }
    /// <summary>
    /// gets the Purchase invoice
    /// </summary>
    public virtual PurchaseInvoice PurchaseInvoice { get; set; }
    public string ProductId { get; set; }
    /// <summary>
    /// gets the product data
    /// </summary>
    public virtual Product Product { get; set; }
    /// <summary>
    /// quantity that has been sold
    /// </summary>
    public decimal Quantity { get; set; }
    /// <summary>
    /// price for sale
    /// </summary>
    public decimal SalePrice { get; set; }
    public string MoneyId { get; set; }
    public string SaleCostId { get; set; }
    /// <summary>
    /// original cost from purchase
    /// </summary>
    public Money SaleCost { get; set; }
    public string? Details { get; set; }
    public string? MeasureUnitId { get; set; }
    /// <summary>
    /// gets the measure unit, if not specified use the product Measure unit, in this 
    /// way is possible to handle the cases in which a product came in a box, but in 
    /// units are packages.
    /// </summary>
    public MeasureUnit? MeasureUnit { get; set; }
}
