using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;

public enum SeatStatus
{
    Available = 1,
    Reserved = 2,
    Sold = 3,
    Blocked = 4
}

public sealed class SeatsAvailability: IAggregateRoot
{
    public int Id { get; set; }
    public int ConferenceId { get; set; }
    public required Conference Conference { get; set; }
    public int AttendeeId { get; set; }
    public SeatStatus Status { get; private set; }
}
