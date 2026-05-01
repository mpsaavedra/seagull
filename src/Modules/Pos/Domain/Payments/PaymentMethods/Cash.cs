using System;
using Pos.Domain.Moneys;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Payments.PaymentMethods;

public sealed class Cash(decimal amount, Currency currency) : ValueObject
{
    public decimal Amount { get; } = amount;
    public Currency Currency { get; } = currency;
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
