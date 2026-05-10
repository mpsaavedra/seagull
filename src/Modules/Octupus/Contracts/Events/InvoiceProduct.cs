using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedInvoiceProduct(string InvoiceProductId);
public sealed record UpdatedInvoiceProduct(InvoiceProductDto InvoiceProduct);
public sealed record DeletedInvoiceProduct(string InvoiceProductId);