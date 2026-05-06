using System;
using Octupus.Contracts.Dtos;
using Seagull.Data;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Moneys;

public partial class Currency : AuditableEntity, IMap<CurrencyDto>
{
    public string Name { get; set; }
    public string? Symbol { get; set; }
    public ICollection<Money> Moneys { get; set; } = [];
}
