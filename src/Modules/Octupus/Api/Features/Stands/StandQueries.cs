using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Stands;

public sealed record GetByIdStand(string Id) : QueryBase;
public sealed record GetStand : PaginatedQueryBase;
