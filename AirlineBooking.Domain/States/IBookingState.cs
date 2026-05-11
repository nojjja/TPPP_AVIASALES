using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.States
{
    public interface IBookingState
    {
        string Name { get; }
        void Confirm(Booking booking);
        void Cancel(Booking booking);
        void Complete(Booking booking);
    }
}
