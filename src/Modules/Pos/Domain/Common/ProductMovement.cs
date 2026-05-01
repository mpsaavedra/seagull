using System;

namespace Pos.Domain.Common;

public sealed record ProductMovementById(string ProductId, decimal Amount);
public sealed record ProductMovementBySku(string Sku, decimal Amount);
