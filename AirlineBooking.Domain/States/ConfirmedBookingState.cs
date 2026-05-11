using System;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.States
{
    public class ConfirmedBookingState : IBookingState
    {
        public string Name
        {
            get { return "Confirmed"; }
        }

        public void Confirm(Booking booking)
        {
            throw new InvalidOperationException("This booking is already confirmed.");
        }

        public void Cancel(Booking booking)
        {
            booking.TransitionTo(new CancelledBookingState());
        }

        public void Complete(Booking booking)
        {
            booking.TransitionTo(new CompletedBookingState());
        }
    }
}
