using System;

namespace Octupus.Api.Features.Warehouses;

public partial class Warehouse
{
    public static Warehouse Create(string Name, bool isAvailable = true, string? AddressId = null) =>
        new() { Name = Name, IsAvailable = isAvailable, AddressId = AddressId };
}
