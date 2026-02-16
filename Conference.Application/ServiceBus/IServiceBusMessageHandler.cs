using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.ServiceBus;
public interface IServiceBusMessageHandler
{
    Task HandleMessageAsync(string messageBody, CancellationToken cancellationToken);
}
