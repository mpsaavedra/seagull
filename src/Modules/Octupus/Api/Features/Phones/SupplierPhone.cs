using System;
using Octupus.Api.Features.Suppliers;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Enums;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public partial class SupplierPhone : AuditableEntity, IMap<SupplierPhoneDto>
{
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
    public string SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}
