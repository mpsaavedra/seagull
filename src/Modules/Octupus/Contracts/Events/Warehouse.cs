using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedWarehouse(string WarehouseId);
public sealed record UpdatedWarehouse(WarehouseDto Warehouse);
public sealed record DeletedWarehouse(string WarehouseId);
