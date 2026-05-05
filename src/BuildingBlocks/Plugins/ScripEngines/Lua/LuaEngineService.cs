using System;
using KeraLua;
using Microsoft.Extensions.Logging;
using NLua;

namespace Seagull.Plugins.ScripEngines.Lua;

public interface ILuaEngineService
{
    // void ExecuteAllPlugins();  
    void ExecuteFile(string filePath);
    Task<Result<LuaResponse>> ExecutePluginAsync<TIn>(string name, TIn input, CancellationToken cancellationToken = default);
}

/// <summary>
/// Usage:
/// <code>
/// // Endpoint to run a specific plugin by name
/// app.MapPost("/plugins/run/{name}", (string name, ILuaEngineService engine, IWebHostEnvironment env) =>
/// {
///     var path = Path.Combine(env.ContentRootPath, "Plugins", $"{name}.lua");
///     if (!File.Exists(path)) return Results.NotFound("Plugin file not found.");
///     
///     engine.ExecuteFile(path);
///     return Results.Ok($"Plugin {name} executed.");
/// });
/// </code>
/// </summary>
public class LuaEngineService : ILuaEngineService
{
    private readonly LuaPluginProvider _provider;
    private readonly PluginDataBridge _bridge;
    private readonly ILogger<LuaEngineService> _logger;

    public LuaEngineService(LuaPluginProvider provider, PluginDataBridge bridge, ILogger<LuaEngineService> logger)
    {
        _provider = provider;
        _bridge = bridge;
        _logger = logger;
    }

    // public void ExecuteAllPlugins()
    // {
    //     var files = _provider.GetPluginFiles();

    //     foreach (var file in files)
    //     {
    //         ExecuteFile(file);
    //     }
    // }

    public void ExecuteFile(string filePath)
    {
        try
        {
            using var lua = new NLua.Lua();
            lua.State.Encoding = System.Text.Encoding.UTF8;
            
            // Expose the bridge
            lua["Seagull"] = _bridge;

            _logger.LogInformation($"Executing plugin: {Path.GetFileName(filePath)}");
            lua.DoFile(filePath);

            // Trigger an entry point function if exists
            var mainFunc = lua["Main"] as NLua.LuaFunction;
            mainFunc?.Call();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in plugin {filePath}: {ex.Message}");
        }
    }

    public async Task<Result<LuaResponse>> ExecutePluginAsync<TIn>(string name, TIn input, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var lua = new NLua.Lua();
            lua.State.Encoding = System.Text.Encoding.UTF8;

            // expose the bridge
            lua["Seagull"] = _bridge;

            // _logger.LogInformation($"Executing plugin: {Path.GetFileName(filePath)}");
            // lua.DoFile(filePath);

            // Trigger an entry point function if exists
            var mainFunc = lua["Main"] as NLua.LuaFunction;
            var result = mainFunc?.Call(input);

            return Result.Success(new LuaResponse(result!));
        }
        catch(Exception ex)
        {
            _logger.LogError(ex.Message);
            return Result.Failure<LuaResponse>(Error.Create("SG_PLGS-00001", ex.Message))!;
        }
    }
}

