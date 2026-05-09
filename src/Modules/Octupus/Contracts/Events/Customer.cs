using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedCustomer(string CustomerId);
public sealed record UpdatedCustomer(CustomerDto Customer);
public sealed record DeletedCustomer(string CustomerId);
