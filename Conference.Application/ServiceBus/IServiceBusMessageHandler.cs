using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.ServiceBus;
public interface IServiceBusMessageHandler<T>
{
    Task HandleMessageAsync(T @event, CancellationToken cancellationToken);
}
