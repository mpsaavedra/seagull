using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Phones;

public sealed record GetBydIdWarehousePhone(string WarehousePhoneId) : QueryBase;
public sealed record GetWarehousePhone : PaginatedQueryBase;