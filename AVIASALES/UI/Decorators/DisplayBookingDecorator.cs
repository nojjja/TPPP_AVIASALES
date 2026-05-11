using AVIASALES.Domain.Entities;

namespace AVIASALES.UI.Decorators
{
    public class DisplayBookingDecorator
    {
        public Booking Booking { get; private set; }

        public DisplayBookingDecorator(Booking booking)
        {
            Booking = booking;
        }

        public string DisplayTitle
        {
            get
            {
                string icon = Booking.Description != null && Booking.Description.Contains("багаж")
                    ? "🧳"
                    : "✈";

                return string.Format(
                    "{0} {1} | {2} | {3} | Total: {4} MDL",
                    icon,
                    Booking.PassengerName,
                    Booking.Description,
                    Booking.StateName,
                    Booking.TotalPrice);
            }
        }
    }
}
