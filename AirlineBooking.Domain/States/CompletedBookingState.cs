using System;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.States
{
    public class CompletedBookingState : IBookingState
    {
        public string Name
        {
            get { return "Completed"; }
        }

        public void Confirm(Booking booking)
        {
            throw new InvalidOperationException("A completed booking cannot be confirmed again.");
        }

        public void Cancel(Booking booking)
        {
            throw new InvalidOperationException("A completed booking cannot be cancelled.");
        }

        public void Complete(Booking booking)
        {
            throw new InvalidOperationException("This booking is already completed.");
        }
    }
}
