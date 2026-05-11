using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStandSaleProduct(string StandSaleProductId);
public sealed record UpdatedStandSaleProduct(StandSaleProductDto StandSaleProduct);
public sealed record DeletedStandSaleProduct(string StandSaleProductId);