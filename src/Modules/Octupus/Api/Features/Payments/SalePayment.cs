using System;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Sales;
using Octupus.Contracts.Enums;
using Seagull.Data;

namespace Octupus.Api.Features.Payments;

public partial class SalePayment : AuditableEntity
{
    public string SaleId { get; set; }
    public virtual Sale Sale { get; set; }
    /// <summary>
    /// tax
    /// </summary>
    public decimal? Tax { get; set; } = 0.0m;
    /// <summary>
    /// discount
    /// </summary>
    public decimal? Discount { get; set; } = 0.0m;
    /// <summary>
    /// 
    /// </summary>
    public decimal TotalPrice { get; set; } = 0.0m;
    /// <summary>
    /// total before taxes and discounts
    /// </summary>
    public decimal SubTotal { get; set; } = 0.0m;
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
