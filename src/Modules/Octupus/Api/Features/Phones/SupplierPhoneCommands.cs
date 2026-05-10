using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public sealed record CreateSupplierPhone : IMap<SupplierPhone>
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string SupplierId { get; set; }
}
public sealed record UpdateSupplierPhone : IMap<SupplierPhone>
{
    public string Id { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string SupplierId { get; set; }
}
public sealed record DeleteSupplierPhone
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}