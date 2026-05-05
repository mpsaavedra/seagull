using System;
using System.Reflection;

namespace Seagull.Plugins;

/// <summary>
/// Returns the Plugins assembly
/// </summary>
public static class PluginsAssembly
{
    /// <summary>
    /// gets the plugins assembly
    /// </summary>
    public static Assembly Assembly = Assembly.GetExecutingAssembly();
}
