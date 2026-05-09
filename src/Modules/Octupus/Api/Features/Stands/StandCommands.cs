using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Stands;

public sealed record CreateStand : IMap<Stand>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public StandType StandType { get; set; }
    public string? AddressId { get; set; }
}
public sealed record UpdateStand : IMap<Stand>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Capacity { get; set; }
    public bool IsAvailable { get; set; }
    public StandType StandType { get; set; }
    public string? AddressId { get; set; }
}
public sealed record DeletStand
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}
