using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Shippings;

public sealed record GetByIdShipping(string Id) : QueryBase;
public sealed record GetShipping : PaginatedQueryBase;