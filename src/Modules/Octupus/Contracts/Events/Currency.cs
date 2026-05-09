using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedCurrency(string CurrencyId);
public sealed record UpdateCurrency(CurrencyDto Currency);
public sealed record DeletedCurrency(string CurrencyId);