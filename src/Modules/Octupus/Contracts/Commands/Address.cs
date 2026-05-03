using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Comands;


public sealed record CreateAddressCommand(string Street, string InnerAddress, string CityId);

public sealed record UpdateAddressCommand(string AddressId, string? Street = null, string? InnerAddress = null, 
    string? CityId = null); 

public sealed record DeleteAddressCommand(string AddressId, bool SoftDelete = true);