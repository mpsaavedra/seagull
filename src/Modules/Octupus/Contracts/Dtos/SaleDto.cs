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
