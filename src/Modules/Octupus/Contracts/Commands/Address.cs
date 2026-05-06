using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Comands;


public sealed record CreateAddress(string Street, string InnerAddress, string CityId);

public sealed record UpdateAddress(string AddressId, string? Street = null, string? InnerAddress = null, 
    string? CityId = null); 

public sealed record DeleteAddress(string AddressId, bool SoftDelete = true);