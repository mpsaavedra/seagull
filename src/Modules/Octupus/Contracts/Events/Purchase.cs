using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedPurchase(string PurchaseId);
public sealed record UpdatedPurchase(PurchaseDto Purchase);
public sealed record DeletedPurchase(string PurchaseId);
