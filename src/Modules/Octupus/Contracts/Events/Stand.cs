using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStand(string StandId);
public sealed record UpdatedStand(StandDto Stand);
public sealed record DeletedStand(string StandId);
