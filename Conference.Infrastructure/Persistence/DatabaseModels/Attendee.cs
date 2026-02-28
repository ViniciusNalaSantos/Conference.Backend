using System;
using System.Collections.Generic;

namespace Conference.Infrastructure.Persistence.DatabaseModels;

public partial class Attendee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
