using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Warehouses;

public sealed record GetWarehouse : PaginatedQueryBase;
public sealed record GetByIdWarehouse(string WarehouseId) : QueryBase;
