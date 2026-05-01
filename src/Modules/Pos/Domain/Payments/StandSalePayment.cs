using System;
using Pos.Contracts.Enums;
using Pos.Domain.Moneys;
using Pos.Domain.Sales;
using Pos.Domain.Stands;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Payments;

public partial class StandSalePayment : AuditableEntity
{
    public StandSalePayment()
    {    
        Tax = 0;
        Discount = 0;
        TotalPrice = 0;
        SubTotal = 0;
    }

    public string StandSaleId { get; set; }
    /// <summary>
    /// stands that ame the sale
    /// </summary>
    public virtual StandSale StandSale { get; set; }
    /// <summary>
    /// tax
    /// </summary>
    public decimal? Tax { get; set; }
    /// <summary>
    /// discount
    /// </summary>
    public decimal? Discount { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal TotalPrice { get; set; }
    /// <summary>
    /// total before taxes
    /// </summary>
    public decimal SubTotal { get; set; }
    public string PriceId { get; set; }
    /// <summary>
    /// price in which the product had been sold
    /// </summary>
    public Money Price { get; set; }
    /// <summary>
    /// payment date
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// due date
    /// </summary>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// gets/sets the purchase payment method used
    /// </summary>
    public PaymentType PaymentType { get; set; }
    
}
