using System;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Sales;
using Octupus.Api.Features.Warehouses;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public partial class SaleProduct : AuditableEntity, IMap<SaleProductDto>
{
    public string ProductId { get; set; }
    public virtual Product Product { get; set; }
    public string SaleId { get; set; }
    public virtual Sale Sale { get; set; }
    public string WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    /// <summary>
    /// quantity that has been sold
    /// </summary>
    public decimal Quantity { get; set; } = 0.0m;
    /// <summary>
    /// price for sale
    /// </summary>
    public decimal SalePrice { get; set; } = 0.0m;
    public string SaleCostId { get; set; }
    /// <summary>
    /// original cost from purchase
    /// </summary>
    public Money SaleCost { get; set; }
    public string? Details { get; set; }
}
