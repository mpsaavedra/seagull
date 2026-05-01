using System;
using Pos.Domain.Invoices;
using Pos.Domain.Payments;
using Pos.Domain.Products;
using Pos.Domain.Shippings;
using Pos.Domain.Suppliers;
using Pos.Domain.Warehouses;
using Seagull.Data;

namespace Pos.Domain.Purchases;

/// <summary>
/// A purchase that is done to an external supplier or retailer
/// </summary>
public partial class Purchase : AuditableEntity
{
    public Purchase()
    {
        Tax = 0.0m;
        Discount = 0.0m;
        TotalPrice = 0.0m;
        SubTotal = 0.0m;
        PurchaseProducts = [];
        PurchasePayments = [];
    }

    /// <summary>
    /// purchase number could also refer to a sequential number or something
    /// like that
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// date in which the purchase has been done
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// date in which the purchase due has to be payed or was payed
    /// </summary>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// tax
    /// </summary
    public decimal? Tax { get; set; }
    /// <summary>
    /// discount
    /// </summary>
    public decimal? Discount { get; set; }
    /// <summary>
    /// Finalprice
    /// </summary>
    public decimal TotalPrice { get; set; }
    /// <summary>
    /// price before taxes
    /// </summary>
    public decimal SubTotal { get; set; }
    /// <summary>
    /// products and related information in this purchase
    /// </summary>
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; }
    /// <summary>
    /// list ofpayments of this purchase
    /// </summary>
    public ICollection<PurchasePayment> PurchasePayments { get; set; }
    // public string? PurchaseInvoiceId { get; set; }
    /// <summary>
    /// Invoice related if applies
    /// </summary>
    public PurchaseInvoice? PurchaseInvoice { get; set; }
    public string WarehouseId { get; set; }
    /// <summary>
    /// warehouse where the purchase has been shipped to
    /// </summary>
    public virtual Warehouse Warehouse { get; set; }
    /// <summary>
    /// cost of shipping if applies
    /// </summary>
    public decimal? ShippingCost { get; set; }
    public string? ShippingId { get; set; }
    /// <summary>
    /// how the puchase has been shipping, it could be null in cases where the user
    /// ships the purchase itself
    /// </summary>
    public virtual Shipping? Shipping { get; set; }
}
