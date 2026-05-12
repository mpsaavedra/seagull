using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Phones;

public sealed record GetByIdWarehousePhone(string Id) : QueryBase;
public sealed record GetWarehousePhone : PaginatedQueryBase;