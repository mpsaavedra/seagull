using System;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Purchases;
using Octupus.Api.Features.Sales;
using Seagull.Data;
using Seagull.Extensions;

namespace Octupus.Api.Features.Warehouses;

/// <summary>
/// 
/// </summary>
public partial class Warehouse : AuditableEntity
{
    private bool _isAvailable;
    public string Name { get; set; }
    public string? AddressId { get; set; }
    public Address? Address { get; set; }
    public ICollection<WarehousePhone> ContactPhones { get; set; } = [];
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
        set
        {
            _isAvailable = value;
        } 
    }
    /// <summary>
    /// list of purchases done by the Warehouse this is the entry point of products
    /// into the system.
    /// </summary>
    public ICollection<Purchase> Purchases { get; set;} = [];
    /// <summary>
    /// gests the list of sales done in this warehouse
    /// </summary>
    public ICollection<Sale> Sales { get; set; } = [];
    /// <summary>
    /// gets the list of products in the wwarehouse
    /// </summary>
    public ICollection<WarehouseProduct> Products { get; set; } = [];
    /// <summary>
    /// gets the lis of products that had been transfer to stands
    /// </summary>
    public ICollection<StandProduct> StandProducts { get; set; } = [];
    /// <summary>
    /// gets the list of products that had been directrly sold from the warehouse
    /// </summary>
    public ICollection<SaleProduct> SaleProducts { get; set; } = [];

    public void Update(string? name = null, Address? address = null, bool? isAvailable = null)
    {
        Name = name.UpdateIfDifferent(Name);
        Address = address is not null ? address : Address;
        IsAvailable = isAvailable ?? IsAvailable; 
    }
}
