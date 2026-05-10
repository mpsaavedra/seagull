using System;
using Octupus.Contracts.Enums;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public sealed record CreateCustomerPhone : IMap<CustomerPhone>
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string CustomerId { get; set; }
}
public sealed record UpdateCustomerPhone : IMap<CustomerPhone>
{
    public string ID { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string CustomerId { get; set; }
}
public sealed record DeleteCustomerPhone
{
    public string ID { get; set; }
    public bool SoftDelte { get; set; } = true;
}