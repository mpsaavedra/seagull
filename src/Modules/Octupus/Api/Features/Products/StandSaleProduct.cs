using System;
using System.ComponentModel.DataAnnotations.Schema;
using Octupus.Api.Features.Moneys;
using Octupus.Api.Features.Sales;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Products;

public partial class StandSaleProduct : AuditableEntity, IMap<StandSaleProductDto>
{
    public string StandSaleId { get; set; }
    public virtual StandSale StandSale { get; set; }
    public string StandProducId { get; set; }
    public virtual StandProduct StandProduct { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public string CostId { get; set; }
    public Money Cost { get; set; }
    public decimal Price { get; set; } = 0.0m;
    /// <summary>
    /// gets the earn which is:<br/>
    /// Quantity * (Price - Cost)
    /// </summary>
    [NotMapped]
    public decimal Earn => Quantity * (Price - Cost.Amount);
}
