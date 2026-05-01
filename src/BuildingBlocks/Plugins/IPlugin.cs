using System;

namespace Seagull.Plugins;

public interface IPlugin
{
    string Name { get; }
    string Version { get; }
    string Description { get; }
    PluginStatus Status { get; }
    
    Task InitializeAsync(CancellationToken cancellationToken = default);
    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync(CancellationToken cancellationToken = default);
}
