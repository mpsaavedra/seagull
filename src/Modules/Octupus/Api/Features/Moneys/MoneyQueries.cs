using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Moneys;

public sealed record GetByIdMoney(string Id) : QueryBase;
public sealed record GetMoney : PaginatedQueryBase;
