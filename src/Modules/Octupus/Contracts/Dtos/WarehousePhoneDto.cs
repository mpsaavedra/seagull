using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record WarehousePhoneDto : DtoBase
{
    public WarehouseDto Warehouse { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}


public sealed record WarehousePhoneListDto : DtoBase
{
    public WarehouseListDto Warehouse { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}