using System;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Seagull.Extensions;
using Seagull.ServiceInstallers;
using Seagull.Messaging.Wolverine;

namespace Octupus.Api;

public static class ServiceCollectionExtensions
{
    public static void InstallOctupusServices(this WebApplicationBuilder builder)
    {
        builder.InstallServicesFromAssembly(Assembly.GetExecutingAssembly());
        builder.InstallServicesFromAssembly(WolverineMessagingAssembly.Assembly);
        builder.AddSeagullServices();
    }

    public static void UseOctupusServices(this WebApplication app)
    {
        app.UseSeagullServices();
    }
}
