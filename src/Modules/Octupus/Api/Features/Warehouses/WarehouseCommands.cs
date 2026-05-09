using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Warehouses;

public sealed record CreateWarehouse : IMap<Warehouse>
{
    private bool IsAvailable { get; set; }
    public string Name { get; set; }
    public string? AddressId { get; set; }
}
public sealed record UpdateWarehouse : IMap<Warehouse>
{
    public string Id { get; set; }
    private bool IsAvailable { get; set; }
    public string Name { get; set; }
    public string? AddressId { get; set; }
}
public sealed record DeleteWarehouse
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}
