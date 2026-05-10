using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetByIdStandSalePayment(string StandSalePaymentId);
public sealed record GetStandSalePayment : PaginatedQueryBase;