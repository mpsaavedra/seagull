using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Suppliers;

public sealed record GetByIdSupplier(string SupplierId) : QueryBase;
public sealed record GetSupplier : PaginatedQueryBase;
