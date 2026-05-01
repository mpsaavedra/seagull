using System;
using System.Diagnostics;
using Pos.Domain.Addresses;
using Pos.Domain.Phones;
using Pos.Domain.Products;
using Pos.Domain.Purchases;
using Pos.Domain.Sales;
using Seagull.Data;
using Seagull.Data.ValueObjects;
using Seagull.Extensions;

namespace Pos.Domain.Warehouses;

/// <summary>
/// 
/// </summary>
public partial class Warehouse : AuditableEntity
{
    private bool _isAvailable;

    protected Warehouse()
    {
        Products = [];
        ContactPhones = [];
        StandProducts = [];
        Sales = [];
        SaleProducts = [];
    }

    public Warehouse(string name, Address address, bool isAvailable = true)
    {
        Name = name;
        Address = address;
        _isAvailable = isAvailable;
    }

    public string Name { get; protected set; }
    public string? AddressId { get; set; }
    public Address? Address { get; protected set; }
    public ICollection<WarehousePhone> ContactPhones { get; protected set; }
    public bool IsAvailable 
    { 
        get
        {
            // TODO: a normal form could be a combination but this has to be consider in a future version
            // return (
            //     from product in Products.ToList()
            //     where product.Quantity > 0
            //     select product
            // ).Any();
            return _isAvailable;
        }
        protected set
        {
            _isAvailable = value;
        } 
    }
    /// <summary>
    /// list of purchases done by the Warehouse this is the entry point of products
    /// into the system.
    /// </summary>
    public ICollection<Purchase> Purchases { get; protected set;}
    /// <summary>
    /// gests the list of sales done in this warehouse
    /// </summary>
    public ICollection<Sale> Sales { get; protected set; }
    /// <summary>
    /// gets the list of products in the wwarehouse
    /// </summary>
    public ICollection<WarehouseProduct> Products { get; protected set; }
    /// <summary>
    /// gets the lis of products that had been transfer to stands
    /// </summary>
    public ICollection<StandProduct> StandProducts { get; protected set; }
    /// <summary>
    /// gets the list of products that had been directrly sold from the warehouse
    /// </summary>
    public ICollection<SaleProduct> SaleProducts { get; protected set; }

    public void Update(string? name = null, Address? address = null, bool? isAvailable = null)
    {
        Name = name.UpdateIfDifferent(Name);
        Address = address is not null ? address : Address;
        IsAvailable = isAvailable ?? IsAvailable; 
    }
}
