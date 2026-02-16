using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Entities;
public enum SeatStatus
{
    Available = 1,
    Reserved = 2,
    Sold = 3,
    Blocked = 4
}
