using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetByIdSalePayment(string Id) : QueryBase;
public sealed record GetSalePayment : PaginatedQueryBase;