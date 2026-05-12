using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Moneys;

public sealed record GetByIdCurrency(string Id) : QueryBase;
public sealed record GetCurrency : PaginatedQueryBase;