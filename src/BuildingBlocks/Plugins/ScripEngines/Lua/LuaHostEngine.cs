using System;

namespace Seagull.Plugins.ScripEngines.Lua;

using NLua;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;


public class LuaHostEngine
{
    private readonly string _basePluginsPath;
    private readonly PluginDataBridge _bridge;

    public LuaHostEngine(IWebHostEnvironment env, PluginDataBridge bridge)
    {
        _bridge = bridge;
        _basePluginsPath = Path.Combine(env.ContentRootPath, "Plugins");

        if (!Directory.Exists(_basePluginsPath)) Directory.CreateDirectory(_basePluginsPath);
    }

    public void InitializeHost()
    {
        using var _lua = new Lua();
        _lua.State.Encoding = System.Text.Encoding.UTF8;

        // 1. Bridge of C#
        _lua["Host"] = _bridge;

        // 2. Configure 'package.path' to plugins path
        var currentPath = _lua["package.path"] as string;
        var customPath = $"{_basePluginsPath}/?._lua;{_basePluginsPath}/?.lua;{_basePluginsPath}/?/init.lua";

        // 3. add our plugins path to _lua's/lua's path
        _lua["package.path"] = $"{customPath.Replace("\\", "/")};{currentPath}";

        // 3. load the plugins core module
        var corePath = Path.Combine(_basePluginsPath, "core", "init.lua");
        if (File.Exists(corePath))
        {
            _lua.DoFile(corePath);
        }

        // 4. load initial plugins- this could be loaded from a json or else
        // LoadPlugin(lua, "inventory-manager");
    }

    private void LoadPlugin(Lua lua, string pluginName)
    {
        try
        {
            // like 'require("inventory-manager")' in Neovim
            lua.DoString($"require('{pluginName}')");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading plugin {pluginName}: {ex.Message}");
        }
    }
}
