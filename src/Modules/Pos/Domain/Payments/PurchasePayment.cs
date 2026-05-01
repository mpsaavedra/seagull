using System;
using Pos.Contracts.Enums;
using Pos.Domain.Purchases;
using Seagull.Data;

namespace Pos.Domain.Payments;

public partial class PurchasePayment : AuditableEntity
{
    protected PurchasePayment()
    {
        
    }

    public string PurchaseId { get; set; }
    /// <summary>
    /// Purchase of this payment
    /// </summary>
    public virtual Purchase Purchase { get; set; }
    /// <summary>
    /// amount payed
    /// </summary>
    public decimal Amount { get; set; }
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
