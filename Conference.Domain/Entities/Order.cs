using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public sealed class Order: IAggregateRoot
{
    private readonly List<Attendee> _attendees = new();

    public int Id { get; private set; }
    public int ConferenceId { get; private set; }
    public IReadOnlyCollection<Attendee> Attendees => _attendees.AsReadOnly();
    public int SeatId { get; private set; }
    public int StatusId { get; private set; }

    private Order() { }
    public Order(int conferenceId, int seatId)
    {
        ConferenceId = conferenceId;
        SeatId = seatId;
    }
    public void AddAttendee(Attendee attendee)
    {
        _attendees.Add(attendee);
    }
}
