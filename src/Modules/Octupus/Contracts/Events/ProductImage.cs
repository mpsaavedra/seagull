using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedProductImage(string ProductImageId);
public sealed record UpdatedProductImage(ProductImageDto ProductImage);
public sealed record DeletedProductImage(string ProductImageId);