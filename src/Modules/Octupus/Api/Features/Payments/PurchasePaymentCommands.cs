using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Payments;

public sealed record CreatePurchasePayment : IMap<PurchasePayment>
{
    public string PurchaseId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}
public sealed record UpdatePurchasePayment : IMap<PurchasePayment>
{
    public string Id { get; set; }
    public string? PurchaseId { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType? PaymentType { get; set; }
}
public sealed record DeletePurchasePayment
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}