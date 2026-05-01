using System;
using Pos.Contracts.Enums;
using Pos.Domain.Warehouses;
using Seagull.Data;

namespace Pos.Domain.Phones;

public partial class WarehousePhone : AuditableEntity
{
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}
