using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record MeasureUnitDto : DtoBase
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<ProductDto> Products { get; set; } = [];
    public ICollection<InvoiceProductDto> InvoiceProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProductDto> PurchaseInvoiceProducts { get; set; } = [];
}
