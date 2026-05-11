using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdStandProduct(string StandProductId);
public sealed record GetStandProduct : PaginatedQueryBase;