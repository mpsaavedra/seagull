using System;
using Seagull.Abstractions.Requests;

namespace Octupus.Api.Features.Invoices;

public sealed record GetByIdInvoice(string Id) : QueryBase;
public sealed record GetInvoice : PaginatedQueryBase;