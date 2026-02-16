using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Messages;
public record CreateOrderMessage
{
    public List<int> AttendeeIdList { get; set; } = new List<int>();
    public int ConferenceId { get; set; }
}
