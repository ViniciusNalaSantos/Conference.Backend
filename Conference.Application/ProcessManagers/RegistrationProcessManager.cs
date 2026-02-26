using Conference.Application.Commands;
using Conference.Application.EventBus;
using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Conference.Application.ProcessManagers;
public class RegistrationProcessManager : IServiceBusMessageHandler<OrderPlacedMessage>
{
    private readonly IServiceBusPublisher _serviceBus;
    public enum ProcessState
    {
        NotStarted = 0,
        AwaitingReservationConfirmation = 1,
        ReservationConfirmationReceived = 2,
        PaymentConfirmationReceived = 3,
    }
    public ProcessState State { get; set; }

    public async Task HandleMessageAsync(OrderPlacedMessage @event, CancellationToken cancellationToken)
    {
        if (this.State == ProcessState.NotStarted)
        {
            this.State = ProcessState.AwaitingReservationConfirmation;

            var command = new MakeSeatReservationCommand
            {
                ConferenceId = @event.ConferenceId,
                ReservationId = Guid.NewGuid(),
                NumberOfSeats = @event.NumberOfSeats,
            };

            await _serviceBus.PublishMessageAsync(command);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}
