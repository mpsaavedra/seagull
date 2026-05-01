using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Warehouses;
using Seagull.Data;

namespace Pos.Domain.Products;

public partial class WarehouseProduct : AuditableEntity
{
    public WarehouseProduct()
    {
        ReOrderLevel = -1;
    }
    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public decimal Quantity { get; set; }
    public decimal? ReOrderLevel { get; set; }
    [NotMapped]
    public bool OnStock => Quantity > 0;
}
