using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Purchases;

public sealed record GetByIdPurchase(string Id) : QueryBase;
public sealed record GetPurchase : PaginatedQueryBase;
