using System;
using System.ComponentModel.DataAnnotations.Schema;
using Pos.Domain.Moneys;
using Pos.Domain.Products;
using Pos.Domain.Sales;
using Seagull.Data;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Products;

public partial class StandSaleProduct : AuditableEntity
{
    public string StandSaleId { get; set; }
    public virtual StandSale StandSale { get; set; }
    public string StandProducId { get; set; }
    public virtual StandProduct StandProduct { get; set; }
    public decimal Quantity { get; set; }
    public string CostId { get; set; }
    public Money Cost { get; set; }
    public decimal Price { get; set; }
    /// <summary>
    /// gets the earn which is:<br/>
    /// Quantity * (Price - Cost)
    /// </summary>
    [NotMapped]
    public decimal Earn => Quantity * (Price - Cost.Amount);
}
