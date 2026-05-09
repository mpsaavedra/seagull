using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedSupplier(string SupplierId);
public sealed record UpdatedSupplier(SupplierDto Supplier);
public sealed record DeletedSupplier(string SupplierId);
