namespace Seagull.Plugins;

/// <summary>
/// posible plugin status
/// </summary>
public enum PluginStatus
{
    Idle,
    Initializing,
    Running,
    Stopping,
    Stopped,
    Unknown
}
