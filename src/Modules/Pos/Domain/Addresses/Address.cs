using System;
using Pos.Domain.Customers;
using Pos.Domain.Stands;
using Pos.Domain.Suppliers;
using Pos.Domain.Warehouses;
using Seagull.Data;

namespace Pos.Domain.Addresses;

public partial class Address : AuditableEntity
{
    public Address()
    {
        Customers = [];
        Stands = [];
        Suppliers = [];
        Warehouses = [];
    }
    public string Street { get; set; }
    public string InnerAddress { get; set; }
    public string? ZipCode { get; set; }
    public string City { get; set; }
    public ICollection<Customer> Customers { get; set; }
    public ICollection<Stand> Stands { get; set; }
    public ICollection<Supplier> Suppliers { get; set;}
    public ICollection<Warehouse> Warehouses { get; set; }
}
