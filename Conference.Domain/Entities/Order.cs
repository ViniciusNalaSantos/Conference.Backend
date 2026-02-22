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
    public int SeatId { get; private set; }
    public OrderStatus Status { get; private set; }

    private Order() { } // EF Core
    public Order(int conferenceId, int seatId)
    {
        ConferenceId = conferenceId;
        SeatId = seatId;
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
}
