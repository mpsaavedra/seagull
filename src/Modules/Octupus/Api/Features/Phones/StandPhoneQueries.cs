using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Phones;

public sealed record GetByIdStandPhone(string Id) : QueryBase;
public sealed record GetStandPhone : PaginatedQueryBase;