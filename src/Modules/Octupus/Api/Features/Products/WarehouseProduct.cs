using System;
using System.ComponentModel.DataAnnotations.Schema;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public partial class WarehouseProduct : AuditableEntity, IMap<WarehouseProductDto>
{
    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public decimal? ReOrderLevel { get; set; } = -1;
    [NotMapped]
    public bool OnStock => Quantity > 0;
}
