using System;

namespace Octupus.Api.Features.Suppliers;

public partial class Supplier
{
    public static Supplier Create(string name, string? addressId = null) =>
        new() { Name = name, AddressId = addressId };
}
