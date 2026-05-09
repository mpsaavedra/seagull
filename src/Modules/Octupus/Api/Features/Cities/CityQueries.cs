using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Cities;

public sealed record GetCity : PaginatedQueryBase;
public sealed record GetById(string CityId) : QueryBase;