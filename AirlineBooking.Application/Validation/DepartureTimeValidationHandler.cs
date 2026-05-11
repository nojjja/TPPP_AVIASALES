using System;

namespace AVIASALES.Application.Validation
{
    public class DepartureTimeValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (request.Flight.Departure <= DateTime.Now)
            {
                throw new BookingValidationException("This flight has already departed and cannot be booked.");
            }

            base.Handle(request);
        }
    }
}
