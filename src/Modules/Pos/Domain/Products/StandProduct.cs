using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Moneys;
using Pos.Domain.Sales;
using Pos.Domain.Stands;
using Pos.Domain.Warehouses;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Products;

public partial class StandProduct : AuditableEntity
{
    public StandProduct()
    {
        StandSaleProducts = [];
        ReOrderLevel = -1;
    }

    public string StandId { get; set; }
    public virtual Stand Stand { get; set; }
    public string ProductId { get; set; }
    public virtual Product Product{ get; set; }
    /// <summary>
    /// quantity on stock
    /// </summary>
    public decimal Quantity { get; set; }
    /// <summary>
    /// sale price
    /// </summary>
    public decimal Price { get; set; }
    public string CostId { get; set; }
    /// <summary>
    /// this is the cost that came from the original purchase in the warehouse
    /// </summary>
    public Money Cost { get; set; }
    public decimal? ReOrderLevel { get; set; }
    public ICollection<StandSaleProduct> StandSaleProducts { get; set; }
    public string WarehouseId { get; set; }
    /// <summary>
    /// wharehouse it comes from
    /// </summary>
    public Warehouse Warehouse { get; set; }
    [NotMapped]
    public bool OnStock => Quantity > 0;
}
