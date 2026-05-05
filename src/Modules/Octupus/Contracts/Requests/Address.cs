using System;

namespace Octupus.Contracts.Requests;

public sealed record CreateAddressRequest(string Street, string InnerAddress, string CityId);

public sealed record UpdateAddressRequest(string AddressId, string? Street = null, string? InnerAddress = null, 
    string? CityId = null); 

public sealed record DeleteAddressRequest(string AddressId, bool SoftDelete = true);
