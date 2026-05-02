using System;
using Octupus.Api.Features.Suppliers;
using Octupus.Contracts.Enums;
using Seagull.Data;

namespace Octupus.Api.Features.Phones;

public partial class SupplierPhone : AuditableEntity
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}
