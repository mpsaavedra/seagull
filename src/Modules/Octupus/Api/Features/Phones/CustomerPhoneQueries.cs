using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Phones;

public sealed record GetByIdCustomerPhone(string Id) : QueryBase;
public sealed record GetCustomerPhone : PaginatedQueryBase;