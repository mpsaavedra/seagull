using System;

namespace Seagull.Plugins.ScripEngines.Lua;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;


public class LuaPluginProvider
{
    private readonly string _pluginsFolder;
    private readonly ILogger<LuaPluginProvider> _logger;

    public LuaPluginProvider(IWebHostEnvironment env, ILogger<LuaPluginProvider> logger)
    {
        _logger = logger;
        // Path: /wwwroot/plugins or /Plugins
        _pluginsFolder = Path.Combine(env.ContentRootPath, "Plugins");

        if (!Directory.Exists(_pluginsFolder))
        {
            Directory.CreateDirectory(_pluginsFolder);
        }
    }

    public IEnumerable<string> GetPluginFiles()
    {
        return Directory.GetFiles(_pluginsFolder, "*.lua");
    }

    public string GetPluginContent(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public string? GetPugin(string name)
    {
        var plugins = GetPlugins();
        return plugins.FirstOrDefault(x => x == name);
    }

    public IEnumerable<string> GetPlugins()
    {
        var directories = 
            from dir  in Directory.GetDirectories(_pluginsFolder)
            where Directory.Exists(Path.Combine(_pluginsFolder, dir, "__init__.lua"))
            select dir;

        return directories;
    }
}