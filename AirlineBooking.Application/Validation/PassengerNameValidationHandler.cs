using System;

namespace AVIASALES.Application.Validation
{
    public class PassengerNameValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PassengerName))
            {
                throw new BookingValidationException("Passenger name is required.");
            }

            if (request.PassengerName.Trim().Length < 2)
            {
                throw new BookingValidationException("Passenger name must contain at least 2 characters.");
            }

            base.Handle(request);
        }
    }
}
