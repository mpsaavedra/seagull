using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedShipping(string ShippingId);
public sealed record UpdateShipping(ShippingDto Shipping);
public sealed record DeletedShipping(string ShippingId);
