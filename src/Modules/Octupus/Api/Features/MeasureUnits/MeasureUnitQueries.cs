using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.MeasureUnits;

public sealed record GetByIdMeasureUnit(string Id) : QueryBase;
public sealed record GetMeasureUnit : PaginatedQueryBase;
