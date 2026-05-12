using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdProduct(string Id) : QueryBase;
public sealed record GetProduct : PaginatedQueryBase;