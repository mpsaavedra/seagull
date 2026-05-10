using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public sealed record CreateWarehousePhone : IMap<WarehousePhone>
{
    public string WarehouseId { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
public sealed record UpdateWarehousePhone : IMap<WarehousePhone>
{
    public string ID { get; set; }
    public string WarehouseId { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
public sealed record DeleteWarehousePhone
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}