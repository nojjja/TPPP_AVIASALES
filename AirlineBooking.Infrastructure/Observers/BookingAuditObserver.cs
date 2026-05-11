using System;
using AVIASALES.Application.Observers;

namespace AVIASALES.Infrastructure.Observers
{
    public class BookingAuditObserver : IBookingObserver
    {
        public void Update(BookingNotification notification)
        {
            Console.WriteLine(
                "[AUDIT] {0}: booking {1} for {2}. Total {3}.",
                notification.EventType,
                notification.Booking.Flight.FlightNumber,
                notification.Booking.PassengerName,
                notification.Booking.TotalPrice);
        }
    }
}
