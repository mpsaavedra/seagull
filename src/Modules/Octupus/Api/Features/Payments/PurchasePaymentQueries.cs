using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Payments;

public sealed record GetByIdPurchasePayment(string Id) : QueryBase;
public sealed record GetPurchasePayment : PaginatedQueryBase;