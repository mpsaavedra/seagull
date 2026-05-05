using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Seagull.Interfaces;
using Seagull.ServiceInstallers;
using System.Collections.Generic;

namespace Seagull.Extensions;

public static class ServiceInstallerServiceCollectionExtensions
{
    /// <summary>
    /// Install all of the services from the specified assembly.
    /// </summary>
    /// <param name="builder">The Web Application builder.</param>
    /// <param name="assembly">The assembly to install services from.</param>
    public static void InstallServicesFromAssembly(this WebApplicationBuilder builder, Assembly assembly, params Type[] types)
    {
        var serviceInstallers = ServiceInstallerFactory.GetServiceInstallersFromAssembly(assembly).ToList();

        serviceInstallers.ForEach(x => x.InstallServices(builder, types));
    }

    /// <summary>
    /// Include all services in the specified assembly into the application pipeline
    /// </summary>
    /// <param name="app"></param>
    /// <param name="assembly"></param>
    public static void UseServicesFromAsembly(this WebApplication app, Assembly assembly)
    {
        var serviceInstallers = ServiceInstallerFactory.GetServiceInstallersFromAssembly(assembly).ToList();

        serviceInstallers.ForEach(x => x.UseServices(app));
    }

    public static void MapEndpointFromAssembly(this WebApplication app, Assembly assembly)
    {
        var mappers = EndpointInstallerFactory.GetEndpointMappersFromAssembly(assembly).ToList();

        mappers.ForEach(x => x.MapEndpoints(app));
    }

    /// <summary>
    /// Registers the transient services from the specified assembly as matching interface.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="assembly">The assembly to scan for transient services.</param>
    public static void AddTransientAsMatchingInterface(this IServiceCollection services, Assembly assembly) =>
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
                .AddClasses(filter => filter.AssignableTo<ITransientLifescope>(), false)
                .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                .AsMatchingInterface()
                .WithTransientLifetime());

    /// <summary>
    /// Registers the transient services from the specified assembly as matching interface.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="assembly">The assembly to scan for transient services.</param>
    public static void AddScopedAsMatchingInterface(this IServiceCollection services, Assembly assembly) =>
        services.Scan(scan =>
            scan.FromAssemblies(assembly)
                .AddClasses(filter => filter.AssignableTo<IScopedLifescope>(), false)
                .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                .AsMatchingInterface()
                .WithTransientLifetime());
}
