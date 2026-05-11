using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedSaleProduct(string SaleProductId);
public sealed record UpdatedSaleProduct(SaleProductDto SaleProduct);
public sealed record DeletedSaleProduct(string SaleProductId);