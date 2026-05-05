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

namespace Octupus.Api;

public static class ServiceCollectionExtensions
{
    public static void InstallOctupusServices<TContext>(this WebApplicationBuilder builder,  
        Action<DbContextOptionsBuilder>? optionsAction = null, params Type[] types)
        where TContext: DbContext
    {
        builder.Services.AddDbContext<TContext>(optionsAction);
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
        
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
