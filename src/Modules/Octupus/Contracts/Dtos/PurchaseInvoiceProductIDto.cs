using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record PurchaseInvoiceProductDto : DtoBase
{
    public PurchaseInvoiceDto PurchaseInvoice { get; set; }
    public ProductDto Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal SalePrice { get; set; }
    public string SaleCostId { get; set; }
    public MoneyDto SaleCost { get; set; }
    public string? Details { get; set; }
    public MeasureUnitDto? MeasureUnit { get; set; }
}


public sealed record PurchaseInvoiceProductListDto : DtoBase
{
    public PurchaseInvoiceListDto PurchaseInvoice { get; set; }
    public ProductListDto Product { get; set; }
    public decimal Quantity { get; set; }
    public decimal SalePrice { get; set; }
    public string SaleCostId { get; set; }
    public MoneyListDto SaleCost { get; set; }
    public string? Details { get; set; }
    public MeasureUnitListDto? MeasureUnit { get; set; }
}