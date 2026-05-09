using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Shippings;

public sealed record GetByIdShipping(string ShippingId) : QueryBase;
public sealed record GetShiping : PaginatedQueryBase;