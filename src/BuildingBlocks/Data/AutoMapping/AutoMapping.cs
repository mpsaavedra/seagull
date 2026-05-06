using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Seagull.Data.AutoMapping;

public class AutoMapping : AutoMapper.Profile
{
    private readonly ILogger<AutoMapping> _logger;
    private readonly List<string> _avoidPrefixes = new()
    {
        "Microsoft", "System", "AutoMapper", "MediatR", "Swashbuckle", "HotChocolate",
        "Scrutor", "Agile", "JetBrains", "netstandard", "GreenDonut",  "Seagull"
    };

    /// <summary>
    /// returns a new <see cref="AutoMapping"/> instance
    /// </summary>
    public AutoMapping()
    {
        var assemblies =
                    (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     let found = _avoidPrefixes.Any(x => assembly.FullName != null &&
                                                 assembly.FullName.StartsWith(x))
                     where (!found)
                     select assembly).ToList();

        foreach (var assembly in assemblies)
        {
            LoadMapping(assembly);
        }
    }

    /// <summary>
    /// returns a new <see cref="AutoMapping"/> instance
    /// </summary>
    /// <param name="logger"></param>
    public AutoMapping(ILogger<AutoMapping> logger)
    {
        _logger = logger;
        _logger?.LogDebug("Loading entities AutoMapping");

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            LoadMapping(assembly);
        }

        _logger?.LogDebug("Available mappings loaded");
    }

    private void LoadMapping(Assembly assembly)
    {
        var mapFrom = typeof(IMap<>);
        var mappingMethod = nameof(IMap<object>.Mapping);
        bool HasInterface(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == mapFrom;
        var types = assembly.GetExportedTypes().Where(x => x.GetInterfaces().Any(HasInterface) &&
                                                           x.Name.Contains("Seagull.Data.AutoMapping")).ToList();
        var argTypes = new Type[] { typeof(AutoMapper.Profile) };

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(mappingMethod);
            if (methodInfo != null)
                methodInfo?.Invoke(instance, [this]);
            else
            {
                var interfaces = type.GetInterfaces().Where(HasInterface).ToList();
                if (interfaces.Count <= 0) continue;

                foreach (var interfaceMethod in interfaces
                             .Select(x => x.GetMethod(mappingMethod, argTypes)))
                {
                    interfaceMethod?.Invoke(instance, [this]);
                }
            }
        }

    }

    public static void LoadMapping(AutoMapper.Profile profile, params Type[] types)
    {
        foreach (var type in types.Select(x => x.Assembly))
        {
            LoadMapping(profile, type);
        }
    }

    public static void LoadMapping(AutoMapper.Profile profile, Assembly assembly)
    {
        var map = typeof(IMap<>);
        var extendedMapFrom = typeof(IMap<>);
        var mappingMethod = nameof(IMap<object>.Mapping);
        var extendMappingMethod = nameof(IMap<object>.Mapping);
        bool HasInterface(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == map;

        bool HasExtendInterface(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == extendedMapFrom;
        // get all types that has the IMap interface
        var tt =
            from type in assembly.GetTypes()
            from interfaceType in type.GetInterfaces()
            select type;
        var d =
            from t in tt
            where t.IsAssignableFrom(typeof(IMap<>))
            select t;
        var d2 = new List<Type>();
        foreach (var type in assembly.GetTypes())
        {
            foreach (var interfaceType in type.GetInterfaces())
            {
                var tt2 = interfaceType.FullName!.Contains("IMap");
                if (interfaceType == typeof(IMap<>))
                    d2.Add(type);
            }
        }
        var types = (
            from type in assembly.GetTypes()
            from interfaceType in type.GetInterfaces()
            where interfaceType == typeof(IMap<>) || interfaceType.FullName!.Contains("IMap")
            select type).ToList();
        var argTypes = new[] { typeof(AutoMapper.Profile) };

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod(mappingMethod);
            if (methodInfo != null)
                // IMapFrom implementation
                try
                {
                    methodInfo.Invoke(instance, [profile]);
                }
                catch
                {
                    methodInfo = type.GetMethod(extendMappingMethod);
                    methodInfo?.Invoke(instance, [profile, instance!]);
                }
            else
            {
                // 
                var interfaces = type.GetInterfaces().Where(x => HasInterface(x) || HasExtendInterface(x)).ToList();
                if (interfaces.Count <= 0) continue;

                foreach (var interfaceMethod in interfaces
                             .Select(x => x.GetMethod(mappingMethod, argTypes)))
                {
                    try
                    {
                        interfaceMethod?.Invoke(instance, [profile]);
                    }
                    catch
                    {
                        methodInfo = type.GetMethod(extendMappingMethod);
                        methodInfo?.Invoke(instance, [profile, instance!]);
                    }
                }
            }
        }
    }
}
