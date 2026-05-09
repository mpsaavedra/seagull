using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Customers;

public sealed record CreateCustomer : IMap<Customer>
{
    public string Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public string? AddressId { get; set; }
    public string? Website { get; set; }
    public string? Notes { get; set; }
    public string? CommercialNumber { get; set; }
    public decimal? PreviousBalance { get; set; } = 0.0m;
}

public sealed record UpdateCustomer : IMap<Customer>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public string? AddressId { get; set; }
    public string? Website { get; set; }
    public string? Notes { get; set; }
    public string? CommercialNumber { get; set; }
    public decimal? PreviousBalance { get; set; } = 0.0m;
}
public sealed record DeleteCustomer
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}