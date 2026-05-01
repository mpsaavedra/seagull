using System;
using Pos.Domain.Moneys;
using Seagull.Data.ValueObjects;

namespace Pos.Domain.Payments.PaymentMethods;

public sealed class Transfer(decimal amount, Currency currency, string fromAccount, string toAccount): ValueObject
{
    public decimal Amount { get; } = amount;
    public Currency Currency { get; } = currency;
    public string FromAccount { get; } = fromAccount;
    public string ToAccount { get; } = toAccount;
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
        yield return FromAccount;
        yield return ToAccount;
    }
}
