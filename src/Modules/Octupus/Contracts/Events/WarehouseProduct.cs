using System;

namespace Octupus.Contracts.Dtos;

public sealed record CreatedWarehouseProduct(string WarehouseProductId);
public sealed record UpdatedWarehouseProduct(WarehouseProductDto WarehouseProduct);
public sealed record DeletedWarehouseProduct(string WarehouseProductId);