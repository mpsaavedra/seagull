using System;
using System.Reflection;
using Seagull.Data.AutoMapping;
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
        builder.Services.AddAutoMapper(GetType().Assembly);
    }

    public void UseServices(WebApplication app)
    {
        app.MapEndpointFromAssembly(OctupusApiAssembly.Assembly);
    }

}
