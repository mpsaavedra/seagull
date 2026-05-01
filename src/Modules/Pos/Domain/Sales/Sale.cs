using Pos.Domain.Customers;
using Pos.Domain.Payments;
using Pos.Domain.Products;
using Pos.Domain.Shippings;
using Pos.Domain.Warehouses;
using Seagull.Data;

namespace Pos.Domain.Sales;


public partial class Sale  : AuditableEntity
{
    public Sale()
    {
        SaleProducts = [];
        SalePayments = [];
    }
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
    public DateTime Date { get; set; }
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
    public ICollection<SaleProduct> SaleProducts { get; set; }
    public ICollection<SalePayment> SalePayments { get; set; }
}
