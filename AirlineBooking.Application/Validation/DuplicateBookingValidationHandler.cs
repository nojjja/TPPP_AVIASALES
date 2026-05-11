using System.Linq;

namespace AVIASALES.Application.Validation
{
    public class DuplicateBookingValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            bool hasDuplicate = request.ExistingBookings.Any(booking =>
                booking.PassengerName == request.PassengerName &&
                booking.Flight.FlightNumber == request.Flight.FlightNumber &&
                booking.StateName != "Cancelled");

            if (hasDuplicate)
            {
                throw new BookingValidationException("An active booking for this passenger and flight already exists.");
            }

            base.Handle(request);
        }
    }
}
