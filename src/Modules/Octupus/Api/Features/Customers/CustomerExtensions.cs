using System;
using JasperFx.Core.Reflection;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Sales;
using Seagull;
using Seagull.Extensions;

namespace Octupus.Api.Features.Customers;

public partial class Customer
{
    public static Result<Customer> Create(string name, string? contactName = null,
        string? email = null, string? addressId = null, string? website = null,
        string? notes = null, string? commercialNumber = null,
        decimal? previousBalance = null) =>
        Result
            .Create(new Customer()
            {
                Name = name,
                ContactName = contactName,
                Email = email,
                AddressId = addressId,
                Website = website,
                Notes = notes,
                CommercialNumber = commercialNumber,
                PreviousBalance = previousBalance
            });

    public Result Update(string? name = null, string? contactName = null,
        string? email = null, string? addressId = null, string? website = null,
        string? notes = null, string? commercialNumber = null,
        decimal? previousBalance = null) =>
        Result
            .Assign(this, !name.IsNullEmptyOrWhiteSpace(), x => x.Name = name!)
            .Assign(this, !contactName.IsNullEmptyOrWhiteSpace(), x => x.ContactName = contactName)
            .Assign(this, !email.IsNullEmptyOrWhiteSpace(), x => x.Email = email)
            .Assign(this, !addressId.IsNullEmptyOrWhiteSpace(), x => x.AddressId = addressId)
            .Assign(this, !website.IsNullEmptyOrWhiteSpace(), x => x.Website = website)
            .Assign(this, !notes.IsNullEmptyOrWhiteSpace(), x => x.Notes = notes)
            .Assign(this, !commercialNumber.IsNullEmptyOrWhiteSpace(), x => x.CommercialNumber = commercialNumber)
            .Assign(this, previousBalance.HasValue, x => x.PreviousBalance = previousBalance);
    
    public Result AddContactPhone(CustomerPhone phone) => 
        Result
            .Check(this, x => x.ContactPhones.Contains(phone), ErrorCodes.OctupusApi.CustomerPhoneAlreadyExists)
            .Bind(this, x => x.ContactPhones.Add(phone));
    
    public Result RemoveContactPhone(CustomerPhone phone) => 
        Result
            .Check(this, x => !x.ContactPhones.Contains(phone), ErrorCodes.OctupusApi.CustomerPhoneDoesNotExists)
            .Bind(this, x => x.ContactPhones.Remove(phone));

    public Result AddSale(Sale sale) => 
        Result
            .Check(this, x => x.Sales.Contains(sale), ErrorCodes.OctupusApi.CustomerSaleAlreadyExists)
            .Bind(this, x => x.Sales.Add(sale));

    public Result RemoveSale(Sale sale) => 
        Result
            .Check(this, x => !x.Sales.Contains(sale), ErrorCodes.OctupusApi.CustomerSaleDoesNotExists)
            .Bind(this, x => x.Sales.Remove(sale));
}
