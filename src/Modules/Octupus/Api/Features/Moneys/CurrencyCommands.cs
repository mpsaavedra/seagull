using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Moneys;

public sealed record CreateCurrency : IMap<Currency>
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
}
public sealed record UpdateCurrency : IMap<Currency>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Symbol { get; set; }
}
public sealed record DeleteCurrency
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}