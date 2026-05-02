using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace Seagull.SourceGenerators.Extensions;

public static class SyntaxProviderExtensions
{
    public static IncrementalValueProvider<ImmutableArray<ITypeSymbol?>> GetRequestedClassTypes<TAttribute>(
        this SyntaxValueProvider syntaxProvider)
        where TAttribute : Attribute
    {
        return syntaxProvider.CreateSyntaxProvider(
            (node, _) => node.IsValidAttribute<TAttribute>(),
            (ctx, _) => ctx.GetRequestedTypesClass<TAttribute>())
            .Where(t => t is not null)
            .Collect();
    }

    public static IncrementalValueProvider<ImmutableArray<ITypeSymbol?>> GetRequestedClassAndInterfacesTypes<TAttribute>(
        this SyntaxValueProvider syntaxProvider)
        where TAttribute : Attribute
    {
        return syntaxProvider.CreateSyntaxProvider(
            (node, _) => node.IsValidAttribute<TAttribute>(),
            (ctx, _) => ctx.GetRequestedTypesClassOrInterface<TAttribute>())
            .Where(t => t is not null)
            .Collect();
    }
    
    public static IncrementalValueProvider<ImmutableArray<ITypeSymbol?>> GetRequestedClassOrStructTypes<TAttribute>(
        this SyntaxValueProvider syntaxProvider)
        where TAttribute : Attribute
    {
        return syntaxProvider.CreateSyntaxProvider(
            (node, _) => node.IsValidAttribute<TAttribute>(),
            (ctx, _) => ctx.GetRequestedTypesClassOrStruct<TAttribute>())
            .Where(t => t is not null)
            .Collect();
    }
    
    public static IncrementalValueProvider<ImmutableArray<IMethodSymbol?>> GetRequestedMethodTypes<TAttribute>(
        this SyntaxValueProvider syntaxProvider)
        where TAttribute : Attribute
    {
        return syntaxProvider.CreateSyntaxProvider(
            (node, _) => node.IsValidAttribute<TAttribute>(),
            (ctx, _) => ctx.GetRequestedTypesMethod<TAttribute>())
            .Where(t => t is not null)
            .Collect();
    }
}
