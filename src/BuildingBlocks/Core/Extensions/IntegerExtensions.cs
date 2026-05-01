using System;

namespace Seagull.Extensions;

/// <summary>
/// Integer related extensions
/// </summary>
public static class IntegerExtensions
{
    public static int UpdateIfDifferent(this int? value, int reference) =>
        value.HasValue ? value.Value : reference;
}
