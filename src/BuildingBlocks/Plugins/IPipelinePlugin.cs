using System;

namespace Seagull.Plugins;

public interface IPipelinePlugin<TContext> : IPlugin
{
    Task<TContext> ExecuteAsync(TContext context, Func<TContext, Task<TContext>> next);
}
