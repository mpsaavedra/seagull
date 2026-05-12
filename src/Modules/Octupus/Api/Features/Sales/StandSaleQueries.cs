using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Sales;

public sealed record GetByIdStandSale(string Id) : QueryBase;
public sealed record GetStandSale : PaginatedQueryBase;