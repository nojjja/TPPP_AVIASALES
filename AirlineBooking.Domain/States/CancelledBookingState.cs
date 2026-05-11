using System;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.States
{
    public class CancelledBookingState : IBookingState
    {
        public string Name
        {
            get { return "Cancelled"; }
        }

        public void Confirm(Booking booking)
        {
            throw new InvalidOperationException("A cancelled booking cannot be confirmed.");
        }

        public void Cancel(Booking booking)
        {
            throw new InvalidOperationException("This booking is already cancelled.");
        }

        public void Complete(Booking booking)
        {
            throw new InvalidOperationException("A cancelled booking cannot be completed.");
        }
    }
}
