using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Octupus.Api.Features.Customers;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Suppliers;
using Octupus.Api.Features.Warehouses;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Addresses;

public partial class Address
{
    public static Result<Address> Create(string street, string innerAddress, string cityId) =>
        Result
            .Create(new Address()
            {
                Street = street,
                InnerAddress = innerAddress,
                CityId = cityId
            })
            .Ensure(x => !string.IsNullOrEmpty(x.Street), ErrorCodes.OctupusApi.AddressStreetCouldNotBeNull)
            .Ensure(x => !string.IsNullOrEmpty(x.InnerAddress), ErrorCodes.OctupusApi.AddressInnerAddressCouldNotBeNull)
            .Ensure(x => !string.IsNullOrEmpty(x.CityId), ErrorCodes.OctupusApi.AddressCityIdCouldNotBeNull);

    public Result UpdateAddress(string street, string innerAddress, string cityId) =>
        Result
            .Assign(this, !string.IsNullOrEmpty(street), x => x.Street = street)
            .Assign(this, !string.IsNullOrEmpty(innerAddress), x => x.InnerAddress = innerAddress)
            .Assign(this, !string.IsNullOrEmpty(CityId), x => x.CityId = cityId);
            
    public Result AddCustomer(Customer customer) =>
        Result
            .Check(this, x => x.Customers.Contains(customer), ErrorCodes.OctupusApi.AddressCustomerAlreadyExists)
            .Bind(this, x => x.Customers.Add(customer));

    public Result RemoveCustomer(Customer customer) =>
        Result
            .Check(this, x => !x.Customers.Contains(customer), ErrorCodes.OctupusApi.AddressCustomerDoesNotExists)
            .Bind(this, x => x.Customers.Remove(customer));

    public Result AddStand(Stand stand) =>
        Result
            .Check(this, x => x.Stands.Contains(stand), ErrorCodes.OctupusApi.AddressStandAlreadyExists)
            .Bind(this, x => x.Stands.Add(stand));

    public Result RemoveStand(Stand stand) =>
        Result
            .Check(this, x => !x.Stands.Contains(stand), ErrorCodes.OctupusApi.AddressStandDoesNotExists)
            .Bind(this, x => x.Stands.Remove(stand));

    public Result AddSupplier(Supplier supplier) =>
        Result
            .Check(this, x => x.Suppliers.Contains(supplier), ErrorCodes.OctupusApi.AddressSupplierAlreadyExists)
            .Bind(this, x => x.Suppliers.Add(supplier));

    public Result RemoveSupplier(Supplier supplier) =>
        Result
            .Check(this, x => !x.Suppliers.Contains(supplier), ErrorCodes.OctupusApi.AddressSupplierDoesNotExists)
            .Bind(this, x => x.Suppliers.Remove(supplier));

    public Result AddWarehouse(Warehouse warehouse) =>
        Result
            .Check(this, x => x.Warehouses.Contains(warehouse), ErrorCodes.OctupusApi.AddressWarehouseAlreadyExists)
            .Bind(this, x => x.Warehouses.Add(warehouse));

    public Result RemoveWarehouse(Warehouse warehouse) =>
        Result
            .Check(this, x => !x.Warehouses.Contains(warehouse), ErrorCodes.OctupusApi.AddressWarehouseDoesNotExists)
            .Bind(this, x => x.Warehouses.Remove(warehouse));

        
}
