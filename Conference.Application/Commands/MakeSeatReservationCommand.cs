using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Commands;
public record MakeSeatReservationCommand
{
    public int ConferenceId { get; set; }
    public Guid ReservationId { get; set; }
    public int NumberOfSeats { get; set; }
}
