using System;
using Pos.Domain.Addresses;
using Pos.Domain.Common;
using Pos.Domain.Sales;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Customers;

public partial class Customer : AuditableEntity
{
    protected Customer()
    {
        ContactPhones = [];
    }

    public string Name { get; protected set; }
    public string? ContactName { get; protected set; }
    public string? Email { get; protected set; }
    public ICollection<CustomerPhone> ContactPhones { get; protected set; }
    public string? AddressId { get; set; }
    public Address? Address { get; protected set; }
    public string? Website { get; protected set; }
    public string? Notes { get; protected set; }
    public string? CommercialNumber { get; protected set; }
    /// <summary>
    /// balance could be used to check for debts
    /// </summary>
    public decimal? PreviousBalance { get; protected set;}
    public ICollection<Sale> Sales { get; protected set; }
}
