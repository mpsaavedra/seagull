using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStandPhone(string StandPhoneId);
public sealed record UpdatedStandPhone(StandPhoneDto StandPhone);
public sealed record DeletedStandPhone(string StandPhoneId);