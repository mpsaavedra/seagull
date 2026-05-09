using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record PurchaseProductDto : DtoBase
{
    public ProductDto Product { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PurchaseDto Purchase { get; set; }
    public decimal Quantity { get; set; }
    public string MoneyId { get; set; }
    public MoneyDto PurchasePrice { get; set; }
    public string? Details { get; set; }
    public SupplierDto? Supplier { get; set; }
}

public sealed record PurchaseProductDetailsDto : DtoBase
{
    public ProductDto Product { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? DueDate { get; set; }
    public PurchaseDto Purchase { get; set; }
    public decimal Quantity { get; set; }
    public string MoneyId { get; set; }
    public MoneyDto PurchasePrice { get; set; }
    public string? Details { get; set; }
    public SupplierDto? Supplier { get; set; }
}
