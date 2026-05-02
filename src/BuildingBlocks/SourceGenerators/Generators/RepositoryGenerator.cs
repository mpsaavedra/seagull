using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Seagull.SourceGenerators.Attributes;
using Seagull.SourceGenerators.Extensions;

namespace Seagull.SourceGenerators.Generators;

[Generator]
public class RepositoryGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(
            context.SyntaxProvider.GetRequestedClassAndInterfacesTypes<RepositoryAttribute>(),
                GenerateRepositoryCode);
    }

    private void GenerateRepositoryCode(SourceProductionContext context, ImmutableArray<ITypeSymbol> types)
    {
        if (types.IsDefaultOrEmpty) return;

        foreach(var type in types)
        {
            if (type == null) continue;
            var (ns, name) = type.GetNameAndNamespace();
            var entity = name.CleanUp();
            var code = $@"{Constants.CodeHeader}
public partial interface {name.CleanUp()}Repository
";
            
            var tns = ns is null ? null : $"{ns}.";
            context.AddSource($"{tns}{name}Repository.g.cs", code);
        }
    }
}
