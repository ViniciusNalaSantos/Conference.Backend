using Conference.Domain.Entities;
using Conference.Domain.Repositories;
using Conference.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Persistence.Repositories;
public class SeatsAvailabilityRepository: ISeatsAvailabilityRepository
{
    private readonly ConferenceDbContext _context;
    public SeatsAvailabilityRepository(ConferenceDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.SeatsAvailability> GetSeatsAvailabilityByConferenceId(int conferenceId)
    {
        var seatAvailability = await _context.SeatsAvailabilities
            .FirstOrDefaultAsync(o =>  o.ConferenceId == conferenceId);

        return Domain.Entities.SeatsAvailability.Rehydrate(
            seatAvailability.Id,
            seatAvailability.ConferenceId,
            seatAvailability.AttendeeId,
            (SeatStatus)seatAvailability.Status
        );
    }

    public async Task Save(SeatsAvailability availability)
    {
        var model = await _context.SeatsAvailabilities
            .FindAsync(availability.Id);

        model?.ApplyToAggregate(availability);

        await _context.SaveChangesAsync();
    }
}
