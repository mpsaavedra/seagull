using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Seagull.Plugins.ScripEngines.Lua;
using Seagull.ServiceInstallers;

namespace Seagull.Plugins;

public class PluginsServiceInstaller : IServiceInstaller
{
    public void InstallServices(WebApplicationBuilder builder, params Type[] types)
    {
        // builder.Services.AddScoped<PluginDataBridge>();
        // builder.Services.AddSingleton<LuaPluginProvider>(); // Singleton is fine for path management
        // builder.Services.AddScoped<ILuaEngineService, LuaEngineService>();
    }

    public void UseServices(WebApplication app)
    {
    }
}
