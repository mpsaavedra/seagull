using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetByIdStandSalePayment(string Id);
public sealed record GetStandSalePayment : PaginatedQueryBase;