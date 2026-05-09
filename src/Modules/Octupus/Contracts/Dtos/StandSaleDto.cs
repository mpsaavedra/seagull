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


public sealed record StandSaleDetailsDto : DtoBase
{
    public StandDetailsDto Stand { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public ICollection<StandSaleProductDetailsDto> SaleProducts { get; set; } = [];
    public ICollection<StandSalePaymentDetailsDto> SalePayments { get; set; } = [];
    public decimal? ShippingCost { get; set; }
    public ShippingDetailsDto? Shipping { get; set; }
}