using System;
using Pos.Domain.Moneys;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Payments.PaymentMethods;

public sealed class Cheque(decimal amount, Currency currency, string number) : ValueObject
{
    public decimal Amount { get; } = amount;
    public Currency Currency { get; } = currency;
    public string Number { get; } = number;
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
        yield return Number;
    }
}
