using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Moneys;

public sealed record GetByIdCurrency(string CurrencyId) : QueryBase;
public sealed record GetCurrency : PaginatedQueryBase;