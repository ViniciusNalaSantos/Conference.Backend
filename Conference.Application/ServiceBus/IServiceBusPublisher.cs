using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.EventBus;
internal interface IServiceBusPublisher
{
    public Task PublishMessage<T>(T message) where T: class;
}
