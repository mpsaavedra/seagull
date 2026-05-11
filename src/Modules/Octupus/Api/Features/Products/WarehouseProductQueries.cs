using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdWarehouseProduct(string WarehouseProductId);
public sealed record GetWarehouseProduct : PaginatedQueryBase;