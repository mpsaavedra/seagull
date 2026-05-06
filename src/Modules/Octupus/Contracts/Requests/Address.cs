using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Contracts.Requests;

public sealed record CreateAddressRequest(string Street, string InnerAddress, string CityId);

public sealed record UpdateAddressRequest(string AddressId, string? Street = null, string? InnerAddress = null, 
    string? CityId = null); 

public sealed record DeleteAddressRequest(string AddressId, bool SoftDelete = true);
public sealed record GetAddressRequest(int PageIndex = 1, int PageSize = 50): PaginatedQueryBase(PageIndex, PageSize);
public sealed record GetAddressById(string addressId);
