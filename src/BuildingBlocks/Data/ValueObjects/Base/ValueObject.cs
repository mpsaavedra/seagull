using Seagull.Data.ShadowProperties;

namespace Seagull.Data.ValueObjects;

/// <summary>
/// Base class for value objects in the Data package.
/// Value objects are immutable objects defined by their values rather than identity.
/// This class provides equality comparison and hashing based on equality components.
/// Implements INotMapped to indicate that value objects should not be mapped directly to database tables.
/// </summary>
/// <remarks>
/// Value objects should be embedded within entities rather than stored as separate tables.
/// Override <see cref="GetEqualityComponents()"/> to specify which properties should be compared for equality.
/// </remarks>
public abstract class ValueObject : INotMapped
{
    /// <summary>
    /// Equality operator for value objects.
    /// Two value objects are equal if their equality components are equal.
    /// </summary>
    /// <param name="left">First value object</param>
    /// <param name="right">Second value object</param>
    /// <returns>True if the value objects are equal, false otherwise</returns>
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Inequality operator for value objects.
    /// </summary>
    /// <param name="left">First value object</param>
    /// <param name="right">Second value object</param>
    /// <returns>True if the value objects are not equal, false otherwise</returns>
    public static bool operator !=(ValueObject left, ValueObject right)
        => !(left == right);

    /// <summary>
    /// Determines whether this value object is equal to another object.
    /// Equality is based on the equality components, not reference equality.
    /// </summary>
    /// <param name="obj">The object to compare with this instance</param>
    /// <returns>True if the objects are equal based on equality components, false otherwise</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        // Check if types are the same (not just assignable) to avoid the bug in IfNotTheSameTypeThrow
        if (GetType() != obj.GetType())
        {
            return false;
        }

        return obj is ValueObject valueObject && GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    /// <summary>
    /// Returns a hash code for this value object.
    /// The hash code is computed from the equality components.
    /// </summary>
    /// <returns>A hash code for this value object</returns>
    public override int GetHashCode()
        => GetEqualityComponents().Aggregate(1, (current, obj) => HashCode.Combine(current, obj));

    /// <summary>
    /// Gets the components that are used to determine equality between value objects.
    /// Override this method in derived classes to specify which properties/fields should be compared.
    /// </summary>
    /// <returns>An enumerable of objects that represent the equality components of this value object</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();
}
