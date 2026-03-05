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
    public int ConferenceId { get; private set; }
    public int AttendeeId { get; set; }
    public SeatStatus Status { get; private set; }

    private SeatsAvailability() { } // EF Core
    
    //public MakeReservation(int reservationId, )

    public static SeatsAvailability Rehydrate(
        int id,
        int conferenceId,
        int attendeeId,
        SeatStatus status
    )
    {
        var seatsAvailability = new SeatsAvailability();

        seatsAvailability.Id = id;
        seatsAvailability.ConferenceId = conferenceId;
        seatsAvailability.AttendeeId = attendeeId;
        seatsAvailability.Status = status;

        return seatsAvailability;
    }
}
