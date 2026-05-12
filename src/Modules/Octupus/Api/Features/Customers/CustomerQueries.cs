using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Customers;

public sealed record GetByIdCustomer(string Id) : QueryBase;
public sealed record GetCustomer : PaginatedQueryBase;
