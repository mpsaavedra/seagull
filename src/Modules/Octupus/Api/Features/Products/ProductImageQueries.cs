using System;
using Octupus.Contracts.Dtos;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Products;

public sealed record GetByIdProductImage(string ProductImageId) : QueryBase;
public sealed record GetProductImage : PaginatedQueryBase;