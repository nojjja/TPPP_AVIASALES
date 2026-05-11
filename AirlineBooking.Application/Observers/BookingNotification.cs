using AVIASALES.Domain.Entities;

namespace AVIASALES.Application.Observers
{
    public class BookingNotification
    {
        public BookingNotification(Booking booking, BookingEventType eventType)
        {
            Booking = booking;
            EventType = eventType;
        }

        public Booking Booking { get; private set; }
        public BookingEventType EventType { get; private set; }
    }
}
