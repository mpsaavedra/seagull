using System;

namespace Pos.Contracts.Events;

public sealed record StandCreated(string Name);
public sealed record StandUpdated(string Id);
public sealed record StandDeleted(string Id);

public sealed record StandUpdatedProductAdded(string StandId, string ProductId);
public sealed record StandUpdateProductsAdded(string StandId, string[] ProductIds);
public sealed record StandUpdateProductRemoved(string StandId, string ProductId);
public sealed record StandUpdateProductsRemoved(string StandId, string[] ProductIds);
