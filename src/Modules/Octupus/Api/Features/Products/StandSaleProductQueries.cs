using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdStandSaleProduct(string Id) : QueryBase;
public sealed record GetStandSaleProduct : PaginatedQueryBase;