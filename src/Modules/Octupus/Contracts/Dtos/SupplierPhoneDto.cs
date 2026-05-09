using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record SupplierPhoneDto : DtoBase
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public SupplierDto Supplier { get; set; }
}


public sealed record SupplierPhoneDetailsDto : DtoBase
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public SupplierDetailsDto Supplier { get; set; }
}