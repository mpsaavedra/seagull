using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Payments;
using Pos.Domain.Products;
using Pos.Domain.Shippings;
using Pos.Domain.Stands;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Sales;

public partial class StandSale : AuditableEntity
{
    public StandSale()
    {   
        SaleProducts = [];
        SalePayments = [];
    }

    public string StandId { get; set; }
    public virtual Stand Stand { get; set; }
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
    /// </summary>
    public decimal? Tax { get; set; }
    /// <summary>
    /// discount
    /// </summary>
    public decimal? Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal SubTotal { get; set; }
    public ICollection<StandSaleProduct> SaleProducts { get; set; }
    public ICollection<StandSalePayment> SalePayments { get; set; }
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
