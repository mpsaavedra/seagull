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
