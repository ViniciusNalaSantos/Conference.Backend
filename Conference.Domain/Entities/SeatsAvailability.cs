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
    public int RemainingSeatsQuantity { get; private set; }

    private SeatsAvailability() { } // EF Core
    
    public void MakeReservation(Guid reservationId, int numberOfSeats)
    {
        if (numberOfSeats > RemainingSeatsQuantity)
        {
            //this.events.Add(new ReservationRejected { ReservationId = reservationId, ConferenceId = this.Id });
        }

        //this.PendingReservations.Add(new Reservation(reservationId, numberOfSeats));
        //this.RemainingSeats -= numberOfSeats;
        //this.events.Add(new ReservationAccepted { ReservationId = reservationId, ConferenceId = this.Id });
    }

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
