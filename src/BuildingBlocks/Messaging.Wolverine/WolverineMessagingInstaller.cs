using System;
using System.Reflection;
using ImTools;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seagull.ServiceInstallers;
using Wolverine;
using Wolverine.Http;
using Wolverine.Postgresql;
using Wolverine.RabbitMQ;

namespace Seagull.Messaging.Wolverine;

public sealed class WolverineMessagingInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder, params Type[] types)
    {
        var config = builder.Configuration;
        
        // builder.Host.UseWolverine(opts => {
        //     // This middleware will apply to the HTTP
        //     // endpoints as well
        //     opts.Policies.AutoApplyTransactions();

        //     // Setting up the outbox on all locally handled
        //     // background tasks
        //     opts.Policies.UseDurableLocalQueues();

        //     // Use Postgres as the message transport (WolverineFx feature)
        //     // opts.PersistMessagesWithPostgresql(builder.Configuration.GetConnectionString("MessagingDb")!);
        //     // opts.UsePostgresqlOutbox();

        //     // opts.UseRabbitMq(cfg =>
        //     // {
        //     //     cfg.HostName =  config["RabbitMq:HostName"];
        //     //     cfg.VirtualHost = config["RabbitMq:VirtualHost"];
        //     //     cfg.UserName = config["RabbitMq:UserName"];
        //     //     cfg.Password = config["RabbitMq:Password"];
        //     // });

        //     // This gives you the option to programmatically
        //     // add other assemblies to the discovery of HTTP endpoints
        //     // or message handlers
        //     // var assembly = Assembly.GetExecutingAssembly();
        //     // opts.Discovery.IncludeAssembly(assembly);
        //     types.ForEach(x => opts.Discovery.IncludeAssembly(x.Assembly));
        // });
        builder.Host.UseWolverine(opts =>
        {
            opts.Policies.AutoApplyTransactions();
            opts.Policies.UseDurableLocalQueues();

            // Get the connection string injected by Aspire
            var connectionString = builder.Configuration.GetConnectionString("messaging");

            if (!string.IsNullOrEmpty(connectionString))
            {
                // Wolverine's RabbitMQ transport accepts a URI directly
                opts.UseRabbitMq(new Uri(connectionString))
                    .AutoProvision() // Automatically create exchanges/queues
                    .AutoPurgeOnStartup(); // Useful for development
            }

            // Assembly discovery
            types.ForEach(x => opts.Discovery.IncludeAssembly(x.Assembly));

            // If you want reliability, consider re-enabling this with your Postgres reference
            // opts.PersistMessagesWithPostgresql(builder.Configuration.GetConnectionString("MessagingDb")!);
            // opts.UsePostgresqlOutbox();
        });

        builder.Services.ConfigureSystemTextJsonForWolverineOrMinimalApi(o =>
        {
            // Do whatever you want here to customize the JSON
            // serialization
            o.SerializerOptions.WriteIndented = true;
        });
        builder.Services.AddWolverineHttp();

        builder.Services.AddScoped<IMessageBus, WolverineMessageBus>();
    }

    public void UseServices(WebApplication app)
    {
        // app.MapWolverineEndpoints();
        app.MapWolverineEndpoints(opts =>
        {
            // All endpoints will be prefixed with /api
            // e.g., /orders becomes /api/orders
            opts.RoutePrefix("api");

        });
    }
}
