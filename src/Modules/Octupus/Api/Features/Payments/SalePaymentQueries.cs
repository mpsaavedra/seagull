using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetByIdSalePayment(string SalePaymentId) : QueryBase;
public sealed record GetSalePayment : PaginatedQueryBase;