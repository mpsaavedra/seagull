using System;

namespace Seagull.Messaging;

public interface IMessageContext
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default);
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default);
    Task ScheduleAsync<TMessage>(TMessage message, DateTimeOffset deliverAt, CancellationToken cancellationToken = default);
}
