using System;
using Seagull.Data;
using Seagull.Exceptions;

namespace Seagull.Extensions;

public static class CollectionExtensions
{
    public static ICollection<T> ToUpdate<T>(this ICollection<T> collection, T value)
        where T : Entity
    {
        var entry = collection.FirstOrDefault(x => x.Id == value.Id);
        if(entry is null)
        {
            throw new SeagullException($"Entity {typeof(T)} with id {value.Id} was not found in collection");
        }
        
        collection.Remove(entry);
        collection.Add(value);

        return collection;
    }
}
