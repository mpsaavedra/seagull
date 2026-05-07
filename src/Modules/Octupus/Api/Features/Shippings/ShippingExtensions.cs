using System;
using Octupus.Contracts.Enums;

namespace Octupus.Api.Features.Shippings;

public partial class Shipping
{
    public static Shipping Create(ShippingType shippingType, string? driverDetails = null) =>
        new() { ShippingType = shippingType, DriverDetails = driverDetails };
}
