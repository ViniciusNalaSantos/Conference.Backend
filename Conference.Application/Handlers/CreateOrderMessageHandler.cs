using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Handlers;
public class CreateOrderMessageHandler : IServiceBusMessageHandler<CreateOrderMessage>
{
    async Task IServiceBusMessageHandler<CreateOrderMessage>.HandleMessageAsync(CreateOrderMessage @event, CancellationToken cancellationToken)
    {
        var order = new Order(
            @event.AttendeeIdList,
            @event.ConferenceId,
            @event.SeatId
        );
    }
}
