using System;
using System.Collections.Generic;

namespace Conference.Infrastructure.Persistence.DatabaseModels;

public partial class Conference
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<SeatsAvailability> SeatsAvailabilities { get; set; } = new List<SeatsAvailability>();
}
