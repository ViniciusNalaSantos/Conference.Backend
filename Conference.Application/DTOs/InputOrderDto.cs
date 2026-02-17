using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.DTOs;
public record InputOrderDto
{
    public List<int> AttendeeIdList { get; set; } = new List<int>();
    public int ConferenceId { get; set; }
    public int SeatId { get; set; }
}

