using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Invoices;

public sealed record GetByIdPurchaseInvoice(string Id) : QueryBase;
public sealed record GetPurchaseInvoice : PaginatedQueryBase;