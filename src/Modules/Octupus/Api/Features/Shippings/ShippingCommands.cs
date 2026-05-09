using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Shippings;

public sealed record ShippingCommands : IMap<Shipping>
{
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
}
public sealed record ShippingUpdate : IMap<Shipping>
{
    public string Id { get; set; }
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
}
public sealed record ShillingDelete
{
    public string Id { get; set; }
    public bool SoftDelte { get; set; } = true;
}
