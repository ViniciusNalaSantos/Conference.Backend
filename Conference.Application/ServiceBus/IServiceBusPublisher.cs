using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.EventBus;
public interface IServiceBusPublisher
{
    public Task PublishMessageAsync<T>(T message) where T: class;
}
