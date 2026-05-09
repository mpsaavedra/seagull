using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Stands;

public sealed record GetByIdStand(string StandId) : QueryBase;
public sealed record GetStand : PaginatedQueryBase;
