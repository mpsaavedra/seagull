using System;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Seagull.Extensions;
using Seagull.ServiceInstallers;
using Seagull.Messaging.Wolverine;
using ImTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Seagull.Data;
using Octupus.Api.Data;
using JasperFx.MultiTenancy;

namespace Octupus.Api;

public static class ServiceCollectionExtensions
{
    public static void InstallOctupusServices<TContext>(this WebApplicationBuilder builder,
        Action<DbContextOptionsBuilder>? optionsAction = null, params Type[] types)
        where TContext : DbContext
    {
        if (optionsAction is not null)
        {
            // connection string from Aspire
            var con = builder.Configuration.GetConnectionString("postgres-server");
            var constring = $"{con};Database=octupus;";
            // configure the DbContext and DbContextFactory
            builder.AddNpgsqlDbContext<ApplicationDbContext>("postgres-server",
                static settings =>
                {
                    // any custom aspire configuration
                },
                optionsAction);
            builder.Services.AddPooledDbContextFactory<TContext>(optionsAction!);
            // add unit of Work
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        }

        // types.ForEach(x => builder.InstallServicesFromAssembly(x.Assembly, types));
        builder.InstallServicesFromAssembly(OctupusApiAssembly.Assembly, types);
        builder.InstallServicesFromAssembly(WolverineMessagingAssembly.Assembly, new List<Type>()
        {
            typeof(ServiceCollectionExtensions)
        }.ToArray());
        builder.AddSeagullServices();

    }

    public static void UseOctupusServices(this WebApplication app)
    {
        app.UseServicesFromAsembly(OctupusApiAssembly.Assembly);
        app.UseServicesFromAsembly(WolverineMessagingAssembly.Assembly);
        app.UseSeagullServices();
    }
}
