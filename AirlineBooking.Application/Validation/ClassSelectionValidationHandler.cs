namespace AVIASALES.Application.Validation
{
    public class ClassSelectionValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ClassType))
            {
                throw new BookingValidationException("Please choose a service class.");
            }

            if (request.ClassType != "Economy" &&
                request.ClassType != "Business" &&
                request.ClassType != "First")
            {
                throw new BookingValidationException("Unknown service class selected.");
            }

            base.Handle(request);
        }
    }
}
