using Seagull.Abstractions.Dtos;

namespace Octupus.Contracts.Dtos;

public sealed record CurrencyDto : DtoBase
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<MoneyDto> Moneys { get; set; } = [];
}


public sealed record CurrencyDetailsDto : DtoBase
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<MoneyDto> Moneys { get; set; } = [];
}