using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Shippings;

public sealed record CreateShipping : IMap<Shipping>
{
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
}
public sealed record UpdateShipping : IMap<Shipping>
{
    public string Id { get; set; }
    public ShippingType ShippingType { get; set; }
    public string? DriverDetails { get; set; }
}
public sealed record DeleteShipping
{
    public string Id { get; set; }
    public bool SoftDelte { get; set; } = true;
}
