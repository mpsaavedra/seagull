using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdPurchaseProduct(string Id) : QueryBase;
public sealed record GetPurchaseProduct : PaginatedQueryBase;