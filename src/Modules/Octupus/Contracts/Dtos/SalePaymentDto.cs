using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record SalePaymentDto : DtoBase
{
    public SaleDto Sale { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public MoneyDto Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}


public sealed record SalePaymentDetailsDto : DtoBase
{
    public SaleDetailsDto Sale { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public MoneyDetailsDto Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}