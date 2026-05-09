using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Categories;

public sealed record GetCategory : PaginatedQueryBase;

public sealed record GetByIdCategory(string CategoryId) : QueryBase();
