using System;
using Octupus.Contracts.Dtos;

namespace Octupus.Contracts.Events;

public sealed record CreatedCategory(string CategoryId);
public sealed record UpdatedCategory(CategoryDto Category);
public sealed record DeletedCategory(string CategoryId);
