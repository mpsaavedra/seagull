using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record PurchaseDto : DtoBase
{
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public ICollection<PurchaseProductDto> PurchaseProducts { get; set; } = [];
    public ICollection<PurchasePaymentDto> PurchasePayments { get; set; } = [];
    public PurchaseInvoiceDto? PurchaseInvoice { get; set; }
    public WarehouseDto Warehouse { get; set; }
    public decimal? ShippingCost { get; set; }
    public ShippingDto? Shipping { get; set; }
}


public sealed record PurchaseListDto : DtoBase
{
    public string Number { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public decimal? Tax { get; set; } = 0.0m;
    public decimal? Discount { get; set; } = 0.0m;
    public decimal TotalPrice { get; set; } = 0.0m;
    public decimal SubTotal { get; set; } = 0.0m;
    public ICollection<PurchaseProductListDto> PurchaseProducts { get; set; } = [];
    public ICollection<PurchasePaymentListDto> PurchasePayments { get; set; } = [];
    public PurchaseInvoiceListDto? PurchaseInvoice { get; set; }
    public WarehouseListDto Warehouse { get; set; }
    public decimal? ShippingCost { get; set; }
    public ShippingListDto? Shipping { get; set; }
}