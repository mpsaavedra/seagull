using System;

namespace Octupus.Contracts.Dtos;

public sealed record CreatedWarehousePhone(string WarehousePhoneId);
public sealed record UpdatedWarehousePhone(WarehousePhoneDto WarehousePhone);
public sealed record DeletedWarehousePhone(string WarehousePhoneId);