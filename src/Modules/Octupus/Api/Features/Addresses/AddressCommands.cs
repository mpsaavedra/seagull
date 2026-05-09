using Octupus.Contracts.Dtos;
using Seagull.Abstractions.Requests;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Addresses;


public sealed record CreateAddress : IMap<Address>
{
    public string Street { get; set; }
    public string InnerAddress { get; set; }
    public string CityId { get; set; }
};
public sealed record UpdateAddress : IMap<Address>
{
    public string Id { get; set; }
    public string? Street { get; set; } = null;
    public string? InnerAddress { get; set; } = null;
    public string? CityId { get; set; } = null;
}
public sealed record DeleteAddress
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}