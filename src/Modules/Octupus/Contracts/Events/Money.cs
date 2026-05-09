using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedMoney(string MoneyId);
public sealed record UpdatedMoney(MoneyDto Money);
public sealed record DeletedMoney(string MoneyId);