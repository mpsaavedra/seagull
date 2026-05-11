using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStandProduct(string StandProductId);
public sealed record UpdatedStandProduct(StandProductDto StandProduct);
public sealed record DeletedStandProduct(string StandProductId);