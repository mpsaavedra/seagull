using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedSupplierPhone(string SupplierPhoneId);
public sealed record UpdatedSupplierPhone(SupplierPhoneDto SupplierPhone);
public sealed record DeletedSupplierPhone(string SupplierPhoneId);