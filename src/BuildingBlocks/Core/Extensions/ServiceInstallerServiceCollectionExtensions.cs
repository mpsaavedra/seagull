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
    public static void InstallServicesFromAssembly(this WebApplicationBuilder builder, Assembly assembly)
    {
        var serviceInstallers = ServiceInstallerFactory.GetServiceInstallersFromAssembly(assembly).ToList();

        serviceInstallers.ForEach(x => x.InstallServices(builder));
    }

    /// <summary>
    /// Install services from assemblies loaded in current context.<br/>
    /// This command should be used with care, because it could load undecired services, use it 
    /// only when you are sure that services to be load are only the ones required, on each assembly
    /// we recommand to use <see cref="InstallServices.Assembly(WebApplicationBuilder, Assembly)"/>
    /// instead
    /// </summary>
    /// <param name="builder"></param>
    public static void InstallServicesFromAssembly(this WebApplicationBuilder builder)
    {
        // all referenced assemblies
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        assemblies.ForEach(builder.InstallServicesFromAssembly);
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
