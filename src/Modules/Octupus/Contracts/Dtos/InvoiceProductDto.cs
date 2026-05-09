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


public sealed record InvoiceProductDetailsDto : DtoBase
{
    public ProductDto Product { get; set; }
    public InvoiceDto Invoice { get; set; }
    public MoneyDto Cost { get; set; }
    public MeasureUnitDto MeasureUnit { get; set; }
    public decimal Quantity { get; set; }
    public string? Description { get; set; }
}