using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedPurchaseInvoice(string PurchaseInvoiceId);
public sealed record UpdatedPurchaseInvoice(PurchaseInvoiceDto PurchaseInvoice);
public sealed record DeletedPurchaseInvoice(string PurchaseInvoiceDto);