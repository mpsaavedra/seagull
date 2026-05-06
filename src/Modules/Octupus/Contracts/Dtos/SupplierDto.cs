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
