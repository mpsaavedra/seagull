using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record StandSaleProductDto : DtoBase
{
    public StandSaleDto StandSale { get; set; }
    public StandProductDto StandProduct { get; set; }
    public decimal Quantity { get; set; } = 0.0m;
    public MoneyDto Cost { get; set; }
    public decimal Price { get; set; } = 0.0m;
}
