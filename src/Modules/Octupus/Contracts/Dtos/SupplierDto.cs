using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record SupplierDto : DtoBase
{
    public string Name { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<SupplierPhoneDto> ContactPhones { get; set; } = [];
    public ICollection<PurchaseProductDto> PurchaseProducts { get; set; } = [];
    public ICollection<InvoiceDto> Invoices { get; set; } = [];
}


public sealed record SupplierListDto : DtoBase
{
    public string Name { get; set; }
    public AddressListDto? Address { get; set; }
    public ICollection<SupplierPhoneListDto> ContactPhones { get; set; } = [];
    public ICollection<PurchaseProductListDto> PurchaseProducts { get; set; } = [];
    public ICollection<InvoiceListDto> Invoices { get; set; } = [];
}