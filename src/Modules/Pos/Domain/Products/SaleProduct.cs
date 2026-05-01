using System;
using Pos.Domain.Invoices;
using Pos.Domain.Moneys;
using Pos.Domain.Sales;
using Pos.Domain.Warehouses;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Products;

public partial class SaleProduct : AuditableEntity
{
    protected SaleProduct()
    {
        Quantity = 0.0m;
    }

    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string SaleId { get; set; }
    public virtual Sale Sale { get; set; }
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    /// <summary>
    /// quantity that has been sold
    /// </summary>
    public decimal Quantity { get; set; }
    /// <summary>
    /// price for sale
    /// </summary>
    public decimal SalePrice { get; set; }
    public string SaleCostId { get; set; }
    /// <summary>
    /// original cost from purchase
    /// </summary>
    public Money SaleCost { get; set; }
    public string? Details { get; set; }
}
