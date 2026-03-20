using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using Conference.Domain.Entities;
using Conference.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Handlers;
public class CreateOrderMessageHandler : IServiceBusMessageHandler<OrderCreatedMessage>
{
    private readonly IOrderRepository _repository;
    public CreateOrderMessageHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    async Task IServiceBusMessageHandler<OrderCreatedMessage>.HandleMessageAsync(OrderCreatedMessage @event, CancellationToken cancellationToken)
    {
        var order = new Order(
            @event.ConferenceId,
            @event.SeatId
        );

        foreach (var id in @event.AttendeeIdList)
        {
            order.AddAttendee(id);
        }

        await _repository.Save(order);
    }
}
