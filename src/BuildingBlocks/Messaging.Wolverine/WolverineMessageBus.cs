using NetTopologySuite.Utilities;
using Wolverine;

namespace Seagull.Messaging.Wolverine;

public class WolverineMessageBus(global::Wolverine.IMessageBus bus) : MessageBus
{
    private readonly global::Wolverine.IMessageBus _bus = bus;
    
    public override Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
    {
        ValidateMessage(command!);
        return _bus.InvokeAsync(command!, cancellationToken);
    }

    public override async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ValidateMessage(@event!);
        await _bus.PublishAsync(@event);
    }

    public override Task<TResponse> InvokeAsync<TResponse>(object request, CancellationToken cancellationToken = default)
    {
        ValidateMessage(request);
        return _bus.InvokeAsync<TResponse>(request, cancellationToken);
    }

    public override async Task ScheduleAsync<TMessage>(TMessage message, DateTimeOffset deliverAt, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ValidateMessage(message!);
        // Wolverine supports scheduling via IMessageContext or IMessageBus extensions.
        // Use the built-in scheduling API
        await _bus.ScheduleAsync<TMessage>(message, deliverAt);
    }
}
