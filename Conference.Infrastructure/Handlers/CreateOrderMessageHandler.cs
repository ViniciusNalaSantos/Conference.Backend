using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Handlers;
public class CreateOrderMessageHandler : IServiceBusMessageHandler<OrderCreatedMessage>
{
    public async Task HandleMessageAsync(OrderCreatedMessage @event, CancellationToken cancellationToken)
    {
        var order = new Order(
            @event.ConferenceId,
            @event.SeatId
        );

        foreach (var id in @event.AttendeeIdList)
        {
            order.AddAttendee(id);
        }

        // _repository.save(order); publishes any events raised by the Order aggregate on the command bus
        // raises OrderPlacedEvent
    }
}
