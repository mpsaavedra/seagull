using System;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Payments;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Api.Features.Shippings;
using Octupus.Api.Features.Warehouses;
using Seagull.Data;

namespace Octupus.Api.Features.Sales;

public partial class Sale  : AuditableEntity
{
    public string WarehouseId { get; set; }
    /// <summary>
    /// gets the warehouse that sold
    /// </summary>
    public virtual Warehouse Warehouse { get; set; }
    public string? CustomerId { get; set; }
    /// <summary>
    /// gets the customer which the warehouse sold, if applies
    /// </summary>
    public virtual Customer? Customer { get; set; }
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
    /// cost of shipping if applies
    /// </summary>
    public decimal? ShippingCost { get; set; }
    public string? ShippingId { get; set; }
    /// <summary>
    /// how the puchase has been shipping, it could be null in cases where the user
    /// ships the purchase itself
    /// </summary>
    public virtual Shipping? Shipping { get; set; }
    public ICollection<SaleProduct> SaleProducts { get; set; } = [];
    public ICollection<SalePayment> SalePayments { get; set; } = [];
}
