using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Suppliers;

public sealed record CreateSupplier : IMap<Supplier>
{
    public string Name { get; set; }
    public string? AddressId { get; set; }
}
public sealed record UpdateSupplier : IMap<Supplier>
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? AddressId { get; set; }
}
public sealed record DeleteSupplier
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}