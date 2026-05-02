using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Seagull.SourceGenerators.Extensions;

public static class SyntaxNodeExtensions
{
    /// <summary>
	/// Creates a unique name for a type which can be used as the hint name in Source Generator output.
	/// </summary>
	/// <param name="type">The type to get the name for</param>
	/// <param name="namespace">The namespace which will be prepended to the type using underscores.</param>
	/// <returns>A unique name for the type inside a generator context.</returns>
	public static string GetHintName(this TypeDeclarationSyntax type, NameSyntax @namespace)
	{
		return string.Concat(@namespace.ToString().Replace('.', '_'), '_', type.Identifier.Text);
	}

	public static bool IsValidAttribute(this SyntaxNode node, string attributeName)
	{
		if (node is not AttributeSyntax attribute)
			return false;
		var name = attribute.Name.ExtractName();
		return attribute.Name.ExtractName() == attributeName.Replace("Attribute", "").LastPart();
	}

	public static bool IsValidAttribute<TAttribute>(this SyntaxNode node) 
		where TAttribute : Attribute =>
		IsValidAttribute(node, typeof(TAttribute).FullName);
}
