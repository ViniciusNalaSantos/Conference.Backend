using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public sealed class Attendee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
