using System;
using System.Reflection;
using System.Text.Json.Serialization;
using Seagull.Data.AutoMapping;
using Seagull.Extensions;
using Seagull.ServiceInstallers;
using Wolverine;

namespace Octupus.Api;

public class OctupusApiServiceInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder, params Type[] types)
    {
        builder.Services.AddSingletonMatchingInterface(OctupusApiAssembly.Assembly);
        builder.Services.AddScopedAsMatchingInterface(OctupusApiAssembly.Assembly);
        builder.Services.AddTransientAsMatchingInterface(OctupusApiAssembly.Assembly);
        builder.Services.AddAutoMapper(GetType().Assembly);

    }

    public void UseServices(WebApplication app)
    {
        app.MapEndpointFromAssembly(OctupusApiAssembly.Assembly);
    }

}
