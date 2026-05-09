using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record CityDto : DtoBase
{
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
}


public sealed record CityDetailsDto : DtoBase
{
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
    public ICollection<AddressDto> Addresses { get; set; } = [];
}
