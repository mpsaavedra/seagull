using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Purchases;

public sealed record GetByIdPurchase(string PurchaseId) : QueryBase;
public sealed record GetPurchase : PaginatedQueryBase;
