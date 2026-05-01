using System.Reflection;

namespace Seagull.Data.Enumerations;

public abstract class Enumeration(int id, string name) : IComparable
{
    public string Name { get; } = name;
    public int Id { get; } = id;
    
    public override string ToString() => Name;

    /// <summary>
    /// returns the list of registered enumerations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
        return fields.Select(f => f.GetValue(null) as T).Cast<T>();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration other) return false;
        return GetType() ==  other.GetType() && Id.Equals(other.Id);
    }
    
    public override int GetHashCode() => Id.GetHashCode();
    
    public int CompareTo(object? obj) => Id.CompareTo(((Enumeration)obj!).Id);

    public static T FromId<T>(int id) where T : Enumeration
    {
        var matchingItems = GetAll<T>().FirstOrDefault(x => x.Id == id);
        if (matchingItems is null)
            throw new InvalidOperationException($"'{id}' is not a valid id in {typeof(T)}");
        return matchingItems;
    }

    public static T FromName<T>(string name) where T : Enumeration
    {
        var matchingItems = GetAll<T>().FirstOrDefault(x => x.Name == name);
        if (matchingItems is null)
            throw new InvalidOperationException($"'{name}' is not a valid name in {typeof(T)}");
        return matchingItems;
    }
}
