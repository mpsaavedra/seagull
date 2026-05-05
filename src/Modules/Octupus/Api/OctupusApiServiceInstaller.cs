using System;
using System.Reflection;
using Seagull.Extensions;
using Seagull.ServiceInstallers;
using Wolverine;

namespace Octupus.Api;

public class OctupusApiServiceInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder, params Type[] types)
    {
        builder.Services.AddTransientAsMatchingInterface(Assembly.GetExecutingAssembly());
        builder.Services.AddScopedAsMatchingInterface(Assembly.GetExecutingAssembly());
    }

    public void UseServices(WebApplication app)
    {
        app.MapEndpointFromAssembly(OctupusApiAssembly.Assembly);
    }

}
