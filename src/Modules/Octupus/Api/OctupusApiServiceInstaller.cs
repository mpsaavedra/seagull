using System;
using System.Reflection;
using Seagull.Extensions;
using Seagull.ServiceInstallers;

namespace Octupus.Api;

public class OctupusApiServiceInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransientAsMatchingInterface(Assembly.GetExecutingAssembly());
        builder.Services.AddScopedAsMatchingInterface(Assembly.GetExecutingAssembly());
    }
}
