using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedWarehousePhone(string WarehousePhoneId);
public sealed record UpdatedWarehousePhone(WarehousePhoneDto WarehousePhone);
public sealed record DeletedWarehousePhone(string WarehousePhoneId);