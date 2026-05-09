using System;
using Seagull.Extensions;

namespace Octupus.Api.Features.Moneys;

public partial class Money
{
    public static Money Create(decimal amount, string currencyId) =>
        new() { Amount = amount, CurrentyId = currencyId };

    public static Money Create(decimal amount, Currency currency) =>
        new() { Amount = amount, Currency = currency };

    public void Update(decimal? amount = null, string? currencyId = null)
    {
        Amount = amount.HasValue ? amount.Value : Amount;
        CurrentyId = currencyId.UpdateIfDifferent(CurrentyId);
    }
}
