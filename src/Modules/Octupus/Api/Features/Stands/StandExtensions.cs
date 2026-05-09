using System;

namespace Octupus.Api.Features.Stands;

public partial class Stand
{
    public static Stand Create(string name, bool isAvailable, string? description, int? capacity) =>
        new()
        {
            Name = name,
            IsAvailable = isAvailable,
            Description = description,
            Capacity = capacity
        };
}
