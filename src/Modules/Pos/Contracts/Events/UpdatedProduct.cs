using System;

namespace Pos.Contracts.Events;

public record UpdatedProduct(string Id, string Name, string SKU);
