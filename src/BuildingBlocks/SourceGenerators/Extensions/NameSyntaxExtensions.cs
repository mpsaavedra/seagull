using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Seagull.SourceGenerators.Extensions;

/// <summary>
/// Name syntax extensions
/// </summary>
public static class NameSyntaxExtensions
{
    /// <summary>
    /// extracts the real canonical name from a <see cref="NameSyntax"/>
    /// </summary>
    /// <param name="nameSyntax"></param>
    /// <returns></returns>
    public static string? ExtractName(this NameSyntax? nameSyntax)=>
        nameSyntax switch
        {
            SimpleNameSyntax ins => ins.Identifier.Text,
            QualifiedNameSyntax qns => qns.Right.Identifier.Text,
            _ => null
        };
}
