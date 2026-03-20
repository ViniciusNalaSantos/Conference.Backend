using Conference.Application.Commands;
using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using Conference.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Application.Handlers;
public class RegistrationHandler : IServiceBusMessageHandler<MakeSeatReservationCommand>
{
    private readonly ISeatsAvailabilityRepository _repository;
    public RegistrationHandler(ISeatsAvailabilityRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleMessageAsync(MakeSeatReservationCommand @event, CancellationToken cancellationToken)
    {
        var availability = await _repository.GetSeatsAvailabilityByConferenceId(@event.ConferenceId);
        availability.MakeReservation(@event.ReservationId, @event.NumberOfSeats);
        await _repository.Save(availability);
    }
}