using System;

namespace Seagull.SourceGenerators.Extensions;

public static class TypeExtensions
{
    public static bool IsNullable(this Type type)
    {
        if (!type.IsValueType) return true; // ref-type
        if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
        return false; // value-type
    }

    public static bool IsNullable<T>(this T obj)
    {
        if (obj == null) return true; // obvious
        Type type = typeof(T);
        if (!type.IsValueType) return true; // ref-type
        if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
        return false; // value-type
    }
}
