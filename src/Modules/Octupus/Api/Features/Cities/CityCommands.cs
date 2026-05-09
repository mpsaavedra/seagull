using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Cities;

public sealed record CreateCity : IMap<City>
{
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
}
public sealed record UpdateCity : IMap<City>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? ZipCode { get; set; }
    public string Town { get; set; }
    public string State { get; set; }
}
public sealed record DeleteCity
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}