using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetBySaleProduct(string SaleProductId) : QueryBase;
public sealed record GetSaleProduct : PaginatedQueryBase;