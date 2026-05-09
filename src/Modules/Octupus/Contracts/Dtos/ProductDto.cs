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
    public DateTime? ExpirationDate { get; set; }
    public MoneyDto Cost { get; set; }
    public MeasureUnitDto MeasureUnit { get; set; }
    public ICollection<PurchaseProductDto> PurchaseProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProductDto> PurchaseInvoiceProducts { get; set; } = [];
    public ICollection<WarehouseProductDto> WarehouseProducts { get; set; } = [];
    public ICollection<StandProductDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductDto> SaleProducts { get; set; } = [];
}

public sealed record ProductListDto : DtoBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string SKU { get; set; }
    public ICollection<ProductImageListDto> Images { get; set; } = [];
    public CategoryDto? Category { get; set; }
    public ICollection<InvoiceProductListDto> InvoiceProducts { get; set; } = [];
    public DateTime? ExpirationDate { get; set; }
    public MoneyDto Cost { get; set; }
    public MeasureUnitListDto MeasureUnit { get; set; }
    public ICollection<PurchaseProductListDto> PurchaseProducts { get; set; } = [];
    public ICollection<PurchaseInvoiceProductListDto> PurchaseInvoiceProducts { get; set; } = [];
    public ICollection<WarehouseProductListDto> WarehouseProducts { get; set; } = [];
    public ICollection<StandProductListDto> StandProducts { get; set; } = [];
    public ICollection<SaleProductListDto> SaleProducts { get; set; } = [];
}
