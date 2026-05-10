using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedStandSalePayment(string StandSalePaymentId);
public sealed record UpdatedStandSalePayment(StandSalePaymentDto StandSalePayment);
public sealed record DeletedStandSalePayment(string StandSalePaymentId);