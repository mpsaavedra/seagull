using System;

namespace Octupus.Contracts.Dtos;

public sealed record CreatedStandPhone(string StandPhoneId);
public sealed record UpdatedStandPhone(StandPhoneDto StandPhone);
public sealed record DeletedStandPhone(string StandPhoneId);