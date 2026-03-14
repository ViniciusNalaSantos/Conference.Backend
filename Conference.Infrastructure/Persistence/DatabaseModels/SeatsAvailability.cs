using System;
using System.Collections.Generic;

namespace Conference.Infrastructure.Persistence.DatabaseModels;

public partial class SeatsAvailability
{
    public int Id { get; set; }

    public int ConferenceId { get; set; }

    public int Status { get; set; }
    public int AttendeeId { get; set; }
    public virtual Conference Conference { get; set; } = null!;

    public virtual Attendee Attendee { get; set; } = null!;

    public void ApplyToAggregate(Domain.Entities.SeatsAvailability aggregate)
    {
        ConferenceId = aggregate.ConferenceId;
        Status = (int)aggregate.Status;
        AttendeeId = aggregate.AttendeeId;
    }
}
