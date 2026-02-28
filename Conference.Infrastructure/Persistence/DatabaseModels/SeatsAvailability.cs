using System;
using System.Collections.Generic;

namespace Conference.Infrastructure.Persistence.DatabaseModels;

public partial class SeatsAvailability
{
    public int Id { get; set; }

    public int ConferenceId { get; set; }

    public int Status { get; set; }

    public virtual Conference Conference { get; set; } = null!;
}
