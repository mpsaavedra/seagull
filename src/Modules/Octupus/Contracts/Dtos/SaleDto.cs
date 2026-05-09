using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record SaleDto : DtoBase
{
    public WarehouseDto Warehouse { get; set; }
    public CustomerDto? Customer { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? ShippingCost { get; set; }
    public ShippingDto? Shipping { get; set; }
    public ICollection<SaleProductDto> SaleProducts { get; set; } = [];
    public ICollection<SalePaymentDto> SalePayments { get; set; } = [];
}

public sealed record SaleListDto : DtoBase
{
    public WarehouseListDto Warehouse { get; set; }
    public CustomerListDto? Customer { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? ShippingCost { get; set; }
    public ShippingListDto? Shipping { get; set; }
    public ICollection<SaleProductListDto> SaleProducts { get; set; } = [];
    public ICollection<SalePaymentListDto> SalePayments { get; set; } = [];
}
