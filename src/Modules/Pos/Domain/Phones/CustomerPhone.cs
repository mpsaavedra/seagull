using System;
using Pos.Contracts.Enums;
using Pos.Domain.Customers;
using Seagull.Data;

namespace Pos.Domain.Common;

public partial class CustomerPhone : AuditableEntity 
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
}
