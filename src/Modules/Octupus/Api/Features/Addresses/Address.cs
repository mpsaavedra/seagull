using System;
using Octupus.Api.Features.Cities;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Suppliers;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Addresses;

public partial class Address : AuditableEntity, IMap<AddressDto>
{
    public string Street { get; set; }
    public string InnerAddress { get; set; }
    public string CityId { get; set; }
    public City City { get; set; }
    public ICollection<Customer> Customers { get; set; } = [];
    public ICollection<Stand> Stands { get; set; } = [];
    public ICollection<Supplier> Suppliers { get; set; } = [];
    public ICollection<Warehouse> Warehouses { get; set; } = [];
}
