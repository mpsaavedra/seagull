using System;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Dtos;
using Octupus.Contracts.Enums;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Phones;

public partial class WarehousePhone : AuditableEntity, IMap<WarehousePhoneDto>
{
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public string Number { get; set; }
    public PhoneType PhoneType { get; set; }
}