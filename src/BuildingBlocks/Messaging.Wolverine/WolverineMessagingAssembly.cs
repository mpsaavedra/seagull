using System;
using System.Reflection;

namespace Seagull.Messaging.Wolverine;


/// <summary>
/// represents the Wolverine messaging assembly
/// </summary>
public class WolverineMessagingAssembly
{
    /// <summary>
    /// Gets the wolverine messaging assembly.
    /// </summary>
    public static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
}
