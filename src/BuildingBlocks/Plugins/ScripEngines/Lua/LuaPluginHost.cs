using System;

namespace Seagull.Plugins.ScripEngines.Lua;

using NLua;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Seagull.Interfaces;


public class LuaPluginHost : IDisposable, ISingletonLifescope
{
    private Lua _lua;
    private readonly string _pluginsPath;
    private readonly PluginDataBridge _bridge;
    private readonly ILogger<LuaPluginHost> _logger;
    private FileSystemWatcher _watcher;

    public LuaPluginHost(IWebHostEnvironment env, PluginDataBridge bridge, ILogger<LuaPluginHost> logger)
    {
        _logger = logger;
        _bridge = bridge;
        _pluginsPath = Path.Combine(env.ContentRootPath, "Plugins");

        InitializeLua();
        SetupWatcher();
    }

    private void InitializeLua()
    {
        _lua?.Dispose();
        _lua = new Lua();
        _lua.State.Encoding = System.Text.Encoding.UTF8;

        // Register the bridge
        _lua["Host"] = _bridge;

        // Neovim-style RTP (Runtime Path) setup
        string customPath = $"{_pluginsPath}/?.lua;{_pluginsPath}/?/init.lua";
        _lua.DoString($@"
            package.path = '{customPath.Replace("\\", "/")};' .. package.path
            _G.Plugins = {{}} -- Global registry for plugins

            local raw_host = Host
            Host = {{}}

            setmetatable(Host, {{__index = raw_host,--allows to read C# methods
                __newindex = function(_, key, _)
                    -- Block any write attempt
                    error('Error: Modification attempt to modify Host property: ' .. key)
                end,
                __metatable = 'Private'-- Hides the metatable for security reasons
            }})
        ");

        LoadAllPlugins();

        // 4. load initial plugins- this could be loaded from a json or else
        // LoadPlugin(lua, "inventory-manager");

        _logger.LogInformation("Lua Host initialized and plugins loaded.");
    }

    private void LoadAllPlugins()
    {
        var directories = Directory.GetDirectories(_pluginsPath);
        foreach (var dir in directories)
        {
            var pluginName = Path.GetFileName(dir);
            if (File.Exists(Path.Combine(dir, "init.lua")))
            {
                try
                {
                    _lua.DoString($"_G.Plugins['{pluginName}'] = require('{pluginName}')");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to load plugin {pluginName}: {ex.Message}");
                }
            }
        }
    }

    private void SetupWatcher()
    {
        _watcher = new FileSystemWatcher(_pluginsPath, "*.lua")
        {
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };

        // Debounce to avoid multiple reloads on rapid saves
        _watcher.Changed += (s, e) =>
        {
            _logger.LogWarning($"Change detected in {e.Name}. Reloading Lua Host...");
            InitializeLua();
        };
    }

    public void CallPluginEvent(string pluginName, string functionName, params object[] args)
    {
        var plugin = _lua.GetTable($"Plugins.{pluginName}");
        var func = plugin?[functionName] as LuaFunction;
        func?.Call(args);
    }

    public void Dispose() => _watcher?.Dispose();
}
