using System;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Enums;
using Seagull.Data;

namespace Octupus.Api.Features.Phones;

public partial class WarehousePhone : AuditableEntity
{
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}