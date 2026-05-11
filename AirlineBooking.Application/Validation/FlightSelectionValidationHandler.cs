namespace AVIASALES.Application.Validation
{
    public class FlightSelectionValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (request.Flight == null)
            {
                throw new BookingValidationException("Please select a flight.");
            }

            base.Handle(request);
        }
    }
}
