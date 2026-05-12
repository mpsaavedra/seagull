using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdSaleProduct(string Id) : QueryBase;
public sealed record GetSaleProduct : PaginatedQueryBase;