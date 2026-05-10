using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetBydIPurchasePayment(string PurchasePaymentId) : QueryBase;
public sealed record GetPurchasePayment : PaginatedQueryBase;