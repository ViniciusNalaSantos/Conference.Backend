using Conference.Application.EventBus;
using Conference.Domain.Entities;
using Conference.Domain.Repositories;
using Conference.Infrastructure.Persistence.DatabaseContext;
using Conference.Infrastructure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Persistence.Repositories;
public class OrderRepository: IOrderRepository
{
    private readonly ConferenceDbContext _context;
    private readonly DomainEventsDispatcher _dispatcher;
    public OrderRepository(ConferenceDbContext context, DomainEventsDispatcher dispatcher) 
    {
        _context = context;
        _dispatcher = dispatcher;
    }

    public async Task<Domain.Entities.Order> GetById(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Attendees)
            .FirstOrDefaultAsync(o => o.Id == id);

        return Domain.Entities.Order.Rehydrate(
            order.Id,
            order.ConferenceId,
            order.SeatsQuantity,
            (OrderStatus)order.Status,
            order.Attendees.Select(o => o.Id)
        );
    }

    public async Task Save(Order order)
    {
        var model = await _context.Orders
            .FindAsync(order.Id);

        model.ApplyToAggregate(order);

        await _context.SaveChangesAsync();

        await _dispatcher.DispatchAsync(order.DomainEvents);
        order.ClearDomainEvent();
    }
}
