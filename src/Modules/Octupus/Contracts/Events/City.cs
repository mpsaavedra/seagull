using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedCity(string CityId);
public sealed record UpdatedCity(CityDto City);
public sealed record DeletedCity(string CityId);
