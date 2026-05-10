using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Payments;

public sealed record CreateStandSalePayment : IMap<StandSalePayment>
{
    public string StandSaleId { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public string PriceId { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}
public sealed record UpdateStandSalePayment : IMap<StandSalePayment>
{
    public string Id { get; set; }
    public string? StandSaleId { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal? TotalPrice { get; set; } = 0.0m;
    public decimal? SubTotal { get; set; } = 0.0m;
    public string? PriceId { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType? PaymentType { get; set; }
}
public sealed record DeleteStandSalePayment
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; }
}