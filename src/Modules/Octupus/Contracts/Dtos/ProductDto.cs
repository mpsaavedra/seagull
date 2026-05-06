using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record ProductDto : DtoBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string SKU { get; set; }
    public ICollection<ProductImageDto> Images { get; set; } = [];
    public CategoryDto? Category { get; set; }
    public ICollection<InvoiceProductDto> InvoiceProducts { get; set; } = [];
    /// </summary>
    public DateTime? ExpirationDate { get; set; }
    public MoneyDto Cost { get; set; }
    public MeasureUnitDto MeasureUnit { get; set; }

    #region Fields related with the status of the product
    public ICollection<PurchaseProductDto> PurchaseProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProductDto> PurchaseInvoiceProducts { get; set; } = [];
    public ICollection<WarehouseProductDto> WarehouseProducts { get; set; } = [];
    public ICollection<StandProductDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductDto> SaleProducts { get; set; } = [];
}
