using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;

public enum OrderStatus
{
    Created = 0,
    Booked = 1,
    Rejected = 2,
    Confirmed = 3
}

public sealed class Order: IAggregateRoot
{
    private readonly List<int> _listAttendeesId = new();
    //private readonly List<IEvents> _events = new();

    public int Id { get; private set; }
    public int ConferenceId { get; private set; }
    public IReadOnlyCollection<int> AttendeesId => _listAttendeesId;
    public int SeatQuantity { get; private set; }
    public OrderStatus Status { get; private set; }

    private Order() { } // EF Core
    public Order(int conferenceId, int seatQuantity)
    {
        ConferenceId = conferenceId;
        SeatQuantity = seatQuantity;
    }
    public void AddAttendee(int attendeeId)
    {
        _listAttendeesId.Add(attendeeId);
    }

    public void MarkAsBooked()
    {
        if (Status != OrderStatus.Created)
        {
            throw new InvalidOperationException();
        }

        Status = OrderStatus.Booked;
    }

    public void Rejected()
    {
        if (Status != OrderStatus.Created)
        {
            throw new InvalidOperationException();
        }

        Status = OrderStatus.Rejected;
    }

    public static Order Rehydrate(
        int id,
        int conferenceId,
        int seatQuantity,
        OrderStatus status,
        IEnumerable<int> attendeesIdList
    )
    {
        var order = new Order();
        
        order.Id = id;
        order.ConferenceId = conferenceId;
        order.SeatQuantity = seatQuantity;
        order.Status = status;

        order._listAttendeesId.AddRange(attendeesIdList);

        return order;
    }
}
