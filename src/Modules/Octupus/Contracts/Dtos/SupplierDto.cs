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


public sealed record SupplierDetailsDto : DtoBase
{
    public string Name { get; set; }
    public AddressDetailsDto? Address { get; set; }
    public ICollection<SupplierPhoneDetailsDto> ContactPhones { get; set; } = [];
    public ICollection<PurchaseProductDetailsDto> PurchaseProducts { get; set; } = [];
    public ICollection<InvoiceDetailsDto> Invoices { get; set; } = [];
}