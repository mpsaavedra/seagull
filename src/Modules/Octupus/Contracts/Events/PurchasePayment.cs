using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedPurchasePayment(string PurchasePaymentId);
public sealed record UpdatedPurchasePayment(PurchasePaymentDto PurchasePayment);
public sealed record DeletedPurchasePayment(string PurchasePaymentId);