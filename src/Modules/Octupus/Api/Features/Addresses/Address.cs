using System;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Suppliers;
using Octupus.Api.Features.Warehouses;
using Seagull.Data;

namespace Octupus.Api.Features.Addresses;

public partial class Address : AuditableEntity
{
    public string Street { get; set; }
    public string InnerAddress { get; set; }
    public string? ZipCode { get; set; }
    public string City { get; set; }
    public ICollection<Customer> Customers { get; set; } = [];
    public ICollection<Stand> Stands { get; set; } = [];
    public ICollection<Supplier> Suppliers { get; set;} = [];
    public ICollection<Warehouse> Warehouses { get; set; } = [];
}
