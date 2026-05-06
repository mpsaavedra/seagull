using System;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Products;
using Octupus.Api.Features.Sales;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Enums;
using Seagull.Data;
using Seagull.Data.AutoMapping;
using Seagull.Extensions;

namespace Octupus.Api.Features.Stands;

/// <summary>
/// Stand refers to a give sale post where the Stand will be installed
/// </summary>
public partial class Stand : AuditableEntity, IMap<StandDto>
{
    private bool _isAvailable = true;

    public static Stand Create(string name, bool isAvailable, string? description, int? capacity) =>
        new()
        {
            Name = name,
            IsAvailable = isAvailable,
            Description = description,
            Capacity = capacity
        };

    /// <summary>
    ///  a name to call or refer to the Stand
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// a simple description that could refers to the porpouse of the Stand
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// capacity of Stand could be clients or any other
    /// </summary>
    public int? Capacity { get; set; }
    /// <summary>
    /// gets if area is available for use
    /// </summary>
    public bool IsAvailable
    {
        get
        {
            // normally a zero stock SHOULD means that is not
            // available but lets keep it this way for now.
            // return _isAvailable && AnyProducOnStock();
            return _isAvailable;
        }
        set
        {
            _isAvailable = value;
        }
    }
    /// <summary>
    /// The stand type. <see cref="StandType"/>
    /// </summary>
    public StandType StandType { get; set; }
    public string? AddressId { get; set; }
    /// <summary>
    /// stand adress
    /// </summary>
    public Address? Address { get; set; }
    /// <summary>
    /// Contact phones
    /// </summary>
    public ICollection<StandPhone> ContactPhones { get; set; } = [];
    /// <summary>
    /// gets the products in a given area/pos
    /// </summary>
    public ICollection<StandProduct> Products { get; set; } = [];
    /// <summary>
    /// get the sales registry
    /// </summary>
    public ICollection<StandSale> Sales { get; set; } = [];

    /// <summary>
    /// update the area basic data, the other information must be updated manually using related
    /// methods
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="capacity"></param>
    /// <param name="isAvailable"></param>
    public void UpdateStand(string? name = null, string? description = null, int? capacity = null,
        bool? isAvailable = null, StandType? standType = null)
    {
        Name = name.UpdateIfDifferent(Name);
        Description = description.UpdateIfDifferent(Description!);
        Capacity = capacity.HasValue ? capacity.Value : Capacity;
        IsAvailable = isAvailable ?? IsAvailable;
        StandType = standType.HasValue ? standType.Value : StandType;
    }

    // /// <summary>
    // /// gets the existent stock
    // /// </summary>
    // public IEnumerable<StockProduct> Stock => 
    //     from product in Products 
    //     where product.Quantity > 0 
    //     select new StockProduct(product.Name, product.Id, product.Quantity);
}

