using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedInvoice(string InvoiceId);
public sealed record UpdatedInvoice(InvoiceDto Invoice);
public sealed record DeletedInvoice(string InvoiceId);