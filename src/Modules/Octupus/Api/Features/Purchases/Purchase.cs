using System;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Shippings;
using Octupus.Api.Features.Warehouses;
using Seagull.Data;

namespace Octupus.Api.Features.Purchases;

/// <summary>
/// A purchase that is done to an external supplier or retailer
/// </summary>
public partial class Purchase : AuditableEntity
{
    /// <summary>
    /// purchase number could also refer to a sequential number or something
    /// like that
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// date in which the purchase has been done
    /// </summary>
    public DateTime Date { get; set; } = DateTime.UtcNow;
    /// <summary>
    /// date in which the purchase due has to be payed or was payed
    /// </summary>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// tax
    /// </summary
    public decimal? Tax { get; set; } = 0.0m;
    /// <summary>
    /// discount
    /// </summary>
    public decimal? Discount { get; set; } = 0.0m;
    /// <summary>
    /// Finalprice
    /// </summary>
    public decimal TotalPrice { get; set; } = 0.0m;
    /// <summary>
    /// price before taxes
    /// </summary>
    public decimal SubTotal { get; set; } = 0.0m;
    /// <summary>
    /// products and related information in this purchase
    /// </summary>
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    /// <summary>
    /// list ofpayments of this purchase
    /// </summary>
    public ICollection<PurchasePayment> PurchasePayments { get; set; } = [];
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

