using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record InvoiceProductDto : DtoBase
{
    public ProductDto Product { get; set; }
    public InvoiceDto Invoice { get; set; }
    public MoneyDto Cost { get; set; }
    public MeasureUnitDto MeasureUnit { get; set; }
    public decimal Quantity { get; set; }
    public string? Description { get; set; }
}


public sealed record InvoiceProductListDto : DtoBase
{
    public ProductListDto Product { get; set; }
    public InvoiceListDto Invoice { get; set; }
    public MoneyListDto Cost { get; set; }
    public MeasureUnitListDto MeasureUnit { get; set; }
    public decimal Quantity { get; set; }
    public string? Description { get; set; }
}