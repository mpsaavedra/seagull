using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandSalePaymentDto : DtoBase
{
    public StandSaleDto StandSale { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public MoneyDto Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}


public sealed record StandSalePaymentDetailsDto : DtoBase
{
    public StandSaleDetailsDto StandSale { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public MoneyDetailsDto Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PaymentType PaymentType { get; set; }
}