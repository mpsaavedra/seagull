using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Seagull.SourceGenerators.Extensions;

public static class GeneratorSyntaxContextExtensions
{
    public static ITypeSymbol? GetRequestedTypesClass<TAttribute>(this GeneratorSyntaxContext context)
        where TAttribute : Attribute
    {
        var attributeSyntax = (AttributeSyntax)context.Node;
        switch (attributeSyntax.Parent?.Parent)
        {
            case ClassDeclarationSyntax classDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(classDeclaration) as ITypeSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            default:
                return null;
        }
    }

    public static ITypeSymbol? GetRequestedTypesClassOrInterface<TAttribute>(this GeneratorSyntaxContext context)
        where TAttribute : Attribute
    {
        var attributeSyntax = (AttributeSyntax)context.Node;
        switch (attributeSyntax.Parent?.Parent)
        {
            case ClassDeclarationSyntax classDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(classDeclaration) as ITypeSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            case InterfaceDeclarationSyntax interfaceDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(interfaceDeclaration) as ITypeSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            default:
                return null;
        }
    }
    
    
    public static ITypeSymbol? GetRequestedTypesClassOrStruct<TAttribute>(this GeneratorSyntaxContext context)
        where TAttribute : Attribute
    {
        var attributeSyntax = (AttributeSyntax)context.Node;
        switch (attributeSyntax.Parent?.Parent)
        {
            case ClassDeclarationSyntax classDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(classDeclaration) as ITypeSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            case StructDeclarationSyntax structDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(structDeclaration) as ITypeSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            default:
                return null;
        }
    }
    
    
    public static IMethodSymbol? GetRequestedTypesMethod<TAttribute>(this GeneratorSyntaxContext context)
        where TAttribute : Attribute
    {
        var attributeSyntax = (AttributeSyntax)context.Node;
        switch (attributeSyntax.Parent?.Parent)
        {
            case MethodDeclarationSyntax methodDeclaration:
            {
                var type = context.SemanticModel.GetDeclaredSymbol(methodDeclaration) as IMethodSymbol;
                return type is null || !type.HasAttribute<TAttribute>() ? null : type;
            }
            default:
                return null;
        }
    }
}
