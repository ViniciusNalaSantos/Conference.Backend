using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.ServiceBus;
public class ServiceBusSettings
{
    public string ConnectionString { get; set; } = default!;
    public string QueueName { get; set; } = default!;
}
