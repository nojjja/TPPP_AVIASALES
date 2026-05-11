using System;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.States
{
    public class CreatedBookingState : IBookingState
    {
        public string Name
        {
            get { return "Created"; }
        }

        public void Confirm(Booking booking)
        {
            booking.TransitionTo(new ConfirmedBookingState());
        }

        public void Cancel(Booking booking)
        {
            booking.TransitionTo(new CancelledBookingState());
        }

        public void Complete(Booking booking)
        {
            throw new InvalidOperationException("A created booking must be confirmed before completion.");
        }
    }
}
