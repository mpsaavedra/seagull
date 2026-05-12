using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Invoices;

public sealed record GetByIdInvoiceProduct(string Id) : QueryBase;
public sealed record GetInvoiceProduct : PaginatedQueryBase;