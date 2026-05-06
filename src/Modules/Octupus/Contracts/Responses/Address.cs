using System;
using System.Net.Sockets;
using Octupus.Contracts.Dtos;
using Seagull.Abstractions.Responses;

namespace Octupus.Contracts.Responses;

public record CreatedAddressResponse(string addressId);
public record GetAddressesResponse(IQueryable<AddressDto> Data, bool HasPreviousPage = false, bool HasNextPage = false): 
    ResponseBase<AddressDto>(Data, HasPreviousPage, HasNextPage);