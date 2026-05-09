using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedAddress(string AdressId);
public sealed record UpdatedAddress(AddressDto Address);
public sealed record DeletedAddress(string AddressId);