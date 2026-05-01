using System;

namespace Seagull.Messaging;

public interface IMessageBus
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default);
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default);
    Task<TResponse> InvokeAsync<TResponse>(object request, CancellationToken cancellationToken = default);
    Task ScheduleAsync<TMessage>(TMessage message, DateTimeOffset deliverAt, CancellationToken cancellationToken = default);
}
