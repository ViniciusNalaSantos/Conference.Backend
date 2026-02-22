using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Messages;
public record OrderPlacedMessage
{
    public int OrderId { get; set; }
    public int ConferenceId { get; set; }
    public int NumberOfSeats { get; set; }
}
