using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Domain.Repositories;
public interface ISeatsAvailabilityRepository: IRepository
{
    Task<SeatsAvailability> GetSeatsAvailabilityByConferenceId(int conferenceId);
    Task Save(SeatsAvailability availability);
}
