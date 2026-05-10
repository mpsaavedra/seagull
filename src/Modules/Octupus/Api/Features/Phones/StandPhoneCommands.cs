using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public sealed record CreateStandPhone : IMap<StandPhone>
{
    public string StandId { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
public sealed record UpdateStandPhone : IMap<StandPhone>
{
    public string Id { get; set; }
    public string StandId { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
public sealed record DeleteStandPhone
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}