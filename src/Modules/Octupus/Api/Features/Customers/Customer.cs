using System;
using Octupus.Api.Features.Addresses;
using Octupus.Api.Features.Phones;
using Octupus.Api.Features.Sales;
using Seagull.Data;

namespace Octupus.Api.Features.Customers;

public partial class Customer : AuditableEntity
{
    public string Name { get; set; }
    public string? ContactName { get; set; }
    public string? Email { get; set; }
    public string? AddressId { get; set; }
    public Address? Address { get; set; }
    public string? Website { get; set; }
    public string? Notes { get; set; }
    public string? CommercialNumber { get; set; }
    /// <summary>
    /// balance could be used to check for debts
    /// </summary>
    public decimal? PreviousBalance { get; set;} = 0.0m;
    public ICollection<CustomerPhone> ContactPhones { get; set; } = [];
    public ICollection<Sale> Sales { get; set; } = [];
}
