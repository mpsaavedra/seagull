using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandSaleDto : DtoBase
{
    public StandDto Stand { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public ICollection<StandSaleProductDto> SaleProducts { get; set; } = [];
    public ICollection<StandSalePaymentDto> SalePayments { get; set; } = [];
    public decimal? ShippingCost { get; set; }
    public ShippingDto? Shipping { get; set; }
}


public sealed record StandSaleListDto : DtoBase
{
    public StandListDto Stand { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public ICollection<StandSaleProductListDto> SaleProducts { get; set; } = [];
    public ICollection<StandSalePaymentListDto> SalePayments { get; set; } = [];
    public decimal? ShippingCost { get; set; }
    public ShippingListDto? Shipping { get; set; }
}