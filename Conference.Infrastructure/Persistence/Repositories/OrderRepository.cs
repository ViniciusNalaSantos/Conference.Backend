using Conference.Domain.Entities;
using Conference.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Persistence.Repositories;
public class OrderRepository
{
    private readonly ConferenceDbContext _context;
    public OrderRepository(ConferenceDbContext context) 
    {
        _context = context;
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
}
