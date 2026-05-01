using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Seagull.Interfaces;
using Seagull.ServiceInstallers;

namespace Seagull.Extensions;

public static class ServiceInstallerServiceCollectionExtensions
{
/// <summary>
        /// Install all of the services from the specified assembly.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="assembly">The assembly to install services from.</param>
        public static void InstallServicesFromAssembly(this WebApplicationBuilder services, Assembly assembly)
        {
            var serviceInstallers = ServiceInstallerFactory.GetServiceInstallersFromAssembly(assembly).ToList();

            serviceInstallers.ForEach(x => x.InstallServices(services));
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
