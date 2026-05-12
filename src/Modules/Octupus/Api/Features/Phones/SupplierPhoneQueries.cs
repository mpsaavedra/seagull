using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Phones;

public sealed record GetByIdSupplierPhone(string Id) : QueryBase;
public sealed record GetSupplierPhone : PaginatedQueryBase;