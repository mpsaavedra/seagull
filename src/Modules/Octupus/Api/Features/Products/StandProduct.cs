using System;
using System.ComponentModel.DataAnnotations.Schema;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Stands;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public partial class StandProduct : AuditableEntity, IMap<StandProductDto>
{
    public string StandId { get; set; }
    public virtual Stand Stand { get; set; }
    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    /// <summary>
    /// quantity on stock
    /// </summary>
    public decimal Quantity { get; set; } = 0.0m;
    /// <summary>
    /// sale price
    /// </summary>
    public decimal Price { get; set; } = 0.0m;
    public string CostId { get; set; }
    /// <summary>
    /// this is the cost that came from the original purchase in the warehouse
    /// </summary>
    public Money Cost { get; set; }
    public decimal? ReOrderLevel { get; set; } = -1;
    public ICollection<StandSaleProduct> StandSaleProducts { get; set; } = [];
    public string WarehouseId { get; set; }
    /// <summary>
    /// wharehouse it comes from
    /// </summary>
    public Warehouse Warehouse { get; set; }
    [NotMapped]
    public bool OnStock => Quantity > 0;
}

