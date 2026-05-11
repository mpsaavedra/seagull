using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedCustomerPhone(string CustomerPhoneId);
public sealed record UpdatedCustomerPhone(CustomerPhoneDto CustomerPhone);
public sealed record DeletedCustomerPhone(string CustomerPhoneId);