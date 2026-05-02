using System;
using Microsoft.CodeAnalysis;

namespace Seagull.SourceGenerators.Extensions;

public static class TypeSymbolExtensions
{
    /// <summary>
    /// Checks if a symbol represents a type which is marked with the specified attribute.
    /// </summary>
    /// <param name="symbol">The symbol to check.</param>
    /// <param name="attribute">The attribute to look for.</param>
    /// <returns>True, if the type is marked with the attribute.</returns>
    public static bool HasAttribute(this ISymbol symbol, INamedTypeSymbol attribute)
    {
        return symbol.GetAttributes().Any(a => attribute.Equals(a.AttributeClass, SymbolEqualityComparer.Default));
    }

    /// <summary>
    /// Gets the symbol for a type.
    /// </summary>
    /// <param name="compilation">The compilation to retrieve the symbol from.</param>
    /// <typeparam name="T">The type for retrieve the symbol for.</typeparam>
    /// <returns>The type's symbol.</returns>
    /// <exception cref="TypeAccessException">If the type cannot be found in the specified compilation.</exception>
    public static INamedTypeSymbol GetSymbolByType<T>(this Compilation compilation)
    {
        var name = typeof(T).FullName;

        return compilation.GetTypeByMetadataName(name) ?? throw new TypeAccessException($"{name} could not be found in compilation.");
    }
    
    /// <summary>
    /// returns true if the given ISymbol has the specified attribute
    /// </summary>
    /// <param name="type"></param>
    /// <param name="attributeName"></param>
    /// <returns></returns>
    public static bool HasAttribute(this ISymbol type, string attributeName) =>
        type.GetAttributes()
            .Any(a =>
                a.AttributeClass?.Name == attributeName.LastPart() &&
                a.AttributeClass.ContainingNamespace is
                {
                    Name: "Oluso",
                    ContainingNamespace.IsGlobalNamespace: true
                });

    /// <summary>
    /// returns true if the given ISymbol has specified attribute
    /// </summary>
    /// <param name="symbol"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool HasAttribute<T>(this ISymbol symbol) where T : Attribute =>
        symbol.HasAttribute(typeof(T).FullName);

    public static IEnumerable<IMethodSymbol?> GetMethods(this ITypeSymbol type)=>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IMethodSymbol field)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IPropertySymbol?> GetPublicProperties(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IPropertySymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Public)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IPropertySymbol?> GetPrivateProperties(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IPropertySymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Private)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IPropertySymbol?> GetProtectedProperties(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IPropertySymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Protected)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IFieldSymbol?> GetPublicFields(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IFieldSymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Public)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IFieldSymbol?> GetPrivateFields(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IFieldSymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Private)
                    return null;
                if (!field.Name.StartsWith("_"))
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IFieldSymbol?> GetProtectedFields(this ITypeSymbol type) =>
        type.GetMembers()
            .Select(m =>
            {
                if (m is not IFieldSymbol field)
                    return null;
                if (field.DeclaredAccessibility is not Accessibility.Protected)
                    return null;
                return field;
            })
            .Where(field => field is not null);

    public static IEnumerable<IMethodSymbol?> GetPublicMethods(this ITypeSymbol type) =>
        type.GetMethods()
            .Select(m =>
            {
                if (m is not IMethodSymbol method)
                    return null;
                if (method.DeclaredAccessibility is not Accessibility.Public)
                    return null;
                return method;
            })
            .Where(method => method is not null);

    public static Dictionary<string?, string?> AsDictionaryNameType(this IEnumerable<IPropertySymbol?> properties) =>
        properties.ToDictionary(prop => prop?.Name, 
            prop => prop?.Type.ToString());

    public static string? GetNamespace(this ITypeSymbol type) =>
        type.ContainingNamespace.IsGlobalNamespace
            ? null
            : type.ContainingNamespace.ToString();

    public static (string? ns, string name) GetNameAndNamespace(this ITypeSymbol type, bool plain = true) =>
        (GetNamespace(type), plain ? type.Name : type.Name.SimpleClassName());

    public static string CollectionTypeToString(this IFieldSymbol field)
    {
        if (!field.Type.ToString().Contains("ICollection"))
            return field.Type.ToString();
        var part = field.Type.ToString().Split('<')[1].LastPart();
        return "ICollection<" + part;
    }

    public static void GetInstancesOfType<T>(this ITypeSymbol type, string nameSuffix = "")
    {
        var types = type.GetType().Assembly.GetExportedTypes()
            .Where(x => 
                    x.IsInstanceOfType(typeof(T)) && 
                    (nameSuffix.IsNullEmptyOrWhiteSpace() || x.Name.EndsWith(nameSuffix))
            );
        // type.GetType().Assembly.GetReferencedAssemblies()
    }
    
    public static bool HasMapper(this ITypeSymbol type) =>
        type.GetPrivateFields().Any(x => x != null && x.Name.Equals("_mapper"));
}
