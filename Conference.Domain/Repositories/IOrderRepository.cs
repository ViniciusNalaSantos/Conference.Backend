using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Repositories;
public interface IOrderRepository: IRepository
{
    Task<Order> GetById(int id);
    Task Save(Order order);
}
