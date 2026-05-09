using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStandSale(string StandSaleId);
public sealed record UpdatedStandSale(StandSaleDto StandSale);
public sealed record DeletedStandSale(string StandSaleId);
