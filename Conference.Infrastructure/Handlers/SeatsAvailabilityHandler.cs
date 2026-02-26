using Conference.Application.Commands;
using Conference.Application.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conference.Infrastructure.Handlers;
public class SeatsAvailabilityHandler : IServiceBusMessageHandler<MakeSeatReservationCommand>
{
    public async Task HandleMessageAsync(MakeSeatReservationCommand @event, CancellationToken cancellationToken)
    {
        //var availability = this.repository.Get(command.ConferenceId);
        //availability.MakeReservation(command.ReservationId, command.Seats);
        //this.repository.Save(availability, command.Id.ToString());
    }
}
