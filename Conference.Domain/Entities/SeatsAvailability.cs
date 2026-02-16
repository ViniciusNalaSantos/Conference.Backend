using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public sealed class SeatsAvailability
{
    public int Id { get; set; }
    public int ConferenceId { get; set; }
    public int StatusId { get; set; }
}
