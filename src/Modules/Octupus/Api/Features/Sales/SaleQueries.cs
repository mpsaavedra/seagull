using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Sales;

public sealed record GetByIdSale(string Id) : QueryBase;
public sealed record GetSale : PaginatedQueryBase;
