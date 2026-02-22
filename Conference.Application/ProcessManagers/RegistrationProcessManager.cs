using Conference.Application.Commands;
using Conference.Application.Messages;
using Conference.Application.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Conference.Application.ProcessManagers;
public class RegistrationProcessManager : IServiceBusMessageHandler<OrderPlacedMessage>
{
    //private readonly List<Envelope<ICommand>> commands = new List<Envelope<ICommand>>();
    public enum ProcessState
    {
        NotStarted = 0,
        AwaitingReservationConfirmation = 1,
        ReservationConfirmationReceived = 2,
        PaymentConfirmationReceived = 3,
    }
    public ProcessState State { get; set; }

    public Task HandleMessageAsync(OrderPlacedMessage @event, CancellationToken cancellationToken)
    {
        if (this.State == ProcessState.NotStarted)
        {
            this.State = ProcessState.AwaitingReservationConfirmation;

            //this.AddCommand(new MakeSeatReservationCommand
            //{
            //    ConferenceId = @event.ConferenceId,
            //    ReservationId = Guid.NewGuid(),
            //    NumberOfSeats = @event.NumberOfSeats,
            //})

        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private void AddCommand<T>(T command) where T : ICommand
    {
        //this.commands.Add(Envelope.Create<ICommand>(command));
    }
}
