using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record PurchasePaymentDto : DtoBase
{
    public PurchaseDto Purchase { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}


public sealed record PurchasePaymentListDto : DtoBase
{
    public PurchaseListDto Purchase { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}