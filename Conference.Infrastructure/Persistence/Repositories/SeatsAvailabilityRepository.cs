using Conference.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Persistence.Repositories;
public class SeatsAvailabilityRepository
{
    private readonly ConferenceDbContext _context;
    public SeatsAvailabilityRepository(ConferenceDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.SeatsAvailability> GetSeatsAvailabilityByConferenceIdAndId(int conferenceId, int id)
    {
        var seatAvailability = await _context.SeatsAvailabilities
            .FirstOrDefaultAsync(o =>  o.ConferenceId == conferenceId && o.Id == id);


    }
}
