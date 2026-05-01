using System;

namespace Pos.Domain.Stands;

public sealed record StandProductOperation(string ProductId, decimal Amount);
