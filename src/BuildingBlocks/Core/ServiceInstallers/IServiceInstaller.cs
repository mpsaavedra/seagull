using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Seagull.ServiceInstallers;

/// <summary>
    /// Represents the service installer interface.
    /// </summary>
    public interface IServiceInstaller
    {
        /// <summary>
        /// Installs the required services using the specified WebApplicationBuilder.
        /// </summary>
        /// <param name="builder">The service collection.</param>
        void InstallServices(WebApplicationBuilder builder);
    }