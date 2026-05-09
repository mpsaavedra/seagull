using System;
using Seagull.Data.AutoMapping;

namespace Octupus.Api.Features.Moneys;

public sealed record CreateMoney : IMap<Money>
{
    public decimal Amount { get; set; }
    public string CurrencyId { get; set; }
}
public sealed record UpdateMoney : IMap<Money>
{
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public string CurrentyId { get; set; }
}
public sealed record DeleteMoney
{
    public string Id { get; set; }
    public bool SoftDelete { get; set; } = true;
}