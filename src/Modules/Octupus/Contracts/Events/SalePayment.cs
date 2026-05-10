using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedSalePayment(string SalePaymentId);
public sealed record UpdatedSalePayment(SalePaymentDto SalePayment);
public sealed record DeletedSalePayment(string SalePaymentId);