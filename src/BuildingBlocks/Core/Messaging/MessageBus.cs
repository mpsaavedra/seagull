using System;

namespace Seagull.Messaging;

public abstract class MessageBus : IMessageBus
{
    public abstract Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default);
    public abstract Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default);
    public abstract Task<TResponse> InvokeAsync<TResponse>(object request, CancellationToken cancellationToken = default);
    public abstract Task ScheduleAsync<TMessage>(TMessage message, DateTimeOffset deliverAt, CancellationToken cancellationToken = default);

    protected static void ValidateMessage(object message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
    }
}
