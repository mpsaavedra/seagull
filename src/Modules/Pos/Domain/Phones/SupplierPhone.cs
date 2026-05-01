using System;
using Pos.Contracts.Enums;
using Pos.Domain.Suppliers;
using Seagull.Data;

namespace Pos.Domain.Phones;

public partial class SupplierPhone : AuditableEntity
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}
