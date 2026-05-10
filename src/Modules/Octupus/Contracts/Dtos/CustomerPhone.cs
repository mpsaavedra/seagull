using System;

namespace Octupus.Contracts.Dtos;

public sealed record CreatedCustomerPhone(string CustomerPhoneId);
public sealed record UpdatedCustomerPhone(CustomerPhoneDto CustomerPhone);
public sealed record DeletedCustomerPhone(string CustomerPhoneId);