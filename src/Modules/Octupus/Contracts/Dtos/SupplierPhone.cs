using System;

namespace Octupus.Contracts.Dtos;

public sealed record CreatedSupplierPhone(string SupplierPhoneId);
public sealed record UpdatedSupplierPhone(SupplierPhoneDto SupplierPhone);
public sealed record DeletedSupplierPhone(string SupplierPhoneId);