using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;

namespace Seagull.ServiceInstallers;

public interface IEndpointInstaller
{
    void MapEndpoints(WebApplication app);    
}

/// <summary>
/// Represents the endpoint mapper factory.
/// </summary>
public static class EndpointInstallerFactory
{
    /// <summary>
    /// Gets all of the endpoint mappers from the specified assembly.
    /// </summary>
    /// <param name="assembly">The assembly to scan for mappers.</param>
    /// <returns>The list of found service mapper instances.</returns>
    public static IEnumerable<IEndpointInstaller> GetEndpointMappersFromAssembly(Assembly assembly)
    {
        Type serviceInstallerType = typeof(IEndpointInstaller);

        IEnumerable<IEndpointInstaller> serviceInstallers = assembly.DefinedTypes
            .Where(x => serviceInstallerType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .Select(x => Activator.CreateInstance(x) as IEndpointInstaller);

        return serviceInstallers;
    }
}
