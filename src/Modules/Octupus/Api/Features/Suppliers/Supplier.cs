using System;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Invoices;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Products;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Suppliers;

/// <summary>
/// Suppliers are the one that user buy a product it could also be called
/// as provider in some point.
/// </summary>
public partial class Supplier : AuditableEntity, IMap<SupplierDto>
{
    /// <summary>
    /// name
    /// </summary>
    public string Name { get; set; }
    public string? AddressId { get; set; }
    /// <summary>
    /// supplier address
    /// </summary>
    public Address? Address { get; set; }
    /// <summary>
    /// supplier contact phone with related information
    /// </summary>
    public ICollection<SupplierPhone> ContactPhones { get; set; } = [];
    /// <summary>
    /// Product purchase done to this supplier
    /// </summary>
    public ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
    public ICollection<Invoice> Invoices { get; set; } = [];
}