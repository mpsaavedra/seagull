using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetBydIdPurchasePayment(string Id) : QueryBase;
public sealed record GetPurchasePayment : PaginatedQueryBase;