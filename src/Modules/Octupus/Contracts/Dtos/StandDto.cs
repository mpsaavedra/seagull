using Octupus.Contracts.Enums;
using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandDto : DtoBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public StandType StandType { get; set; }
    public AddressDto? Address { get; set; }
    public ICollection<StandPhoneDto> ContactPhones { get; set; } = [];
    public ICollection<StandProductDto> Products { get; set; } = [];
    public ICollection<StandSaleDto> Sales { get; set; } = [];
}


public sealed record StandListDto : DtoBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public StandType StandType { get; set; }
    public AddressListDto? Address { get; set; }
    public ICollection<StandPhoneListDto> ContactPhones { get; set; } = [];
    public ICollection<StandProductListDto> Products { get; set; } = [];
    public ICollection<StandSaleListDto> Sales { get; set; } = [];
}