using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.MeasureUnits;

public sealed record CreateMeasureUnit : IMap<MeasureUnit>
{
    public string? Symbol { get; set; }
    public string Name { get; set; }
}
public sealed record UpdateMeasureUnit : IMap<MeasureUnit>
{
    public string Id { get; set; }
    public string? Symbol { get; set; }
    public string Name { get; set; }
}
public sealed record DeleteMeasureUnit
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}