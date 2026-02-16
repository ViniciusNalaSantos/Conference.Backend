using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public sealed class Orders: IAggregateRoot
{
    public int Id { get; set; }
    public int ConferenceId { get; set; }
    public required Conferences Conference { get; set; }
    public int AttendeeId { get; set; }
    public required Attendees Attendee { get; set; }
    public int SeatId { get; set; }
    public required SeatsAvailability Seat { get; set; }
    public int StatusId { get; set; }
}
