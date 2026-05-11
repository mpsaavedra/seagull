using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedProduct(string ProductId);
public sealed record UpdatedProduct(ProductDto Product);
public sealed record DeletedProduct(string ProductId);