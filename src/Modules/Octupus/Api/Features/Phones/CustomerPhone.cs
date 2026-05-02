using System;
using Octupus.Api.Features.Customers;
using Octupus.Contracts.Enums;
using Seagull.Data;

namespace Octupus.Api.Features.Phones;

public partial class CustomerPhone : AuditableEntity 
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
