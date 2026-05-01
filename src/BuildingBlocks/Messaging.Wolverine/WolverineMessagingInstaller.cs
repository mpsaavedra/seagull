using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seagull.ServiceInstallers;
using Wolverine;
using Wolverine.Postgresql;

namespace Seagull.Messaging.Wolverine;

public sealed class WolverineMessagingInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Host.UseWolverine(opts => {
            // Use Postgres as the message transport (WolverineFx feature)
            // opts.PersistMessagesWithPostgresql(builder.Configuration.GetConnectionString("MessagingDb")!);
            // opts.UsePostgresqlOutbox();
        });
    }
}
