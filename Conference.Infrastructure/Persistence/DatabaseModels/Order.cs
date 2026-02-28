using System;
using System.Collections.Generic;

namespace Conference.Infrastructure.Persistence.DatabaseModels;

public partial class Order
{
    public int Id { get; set; }

    public int ConferenceId { get; set; }

    public int Status { get; set; }

    public int SeatsQuantity { get; set; }

    public virtual Conference Conference { get; set; } = null!;

    public virtual ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
}
