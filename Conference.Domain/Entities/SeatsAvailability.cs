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
    public int Id { get; private set; }
    public Conferencea Conference { get; private set; }
    public int AttendeeId { get; set; }
    public SeatStatus Status { get; private set; }

    private SeatsAvailability() { } // EF Core
    //public MakeReservation(int reservationId, )
}
