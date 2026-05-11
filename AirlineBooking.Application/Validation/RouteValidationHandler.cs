namespace AVIASALES.Application.Validation
{
    public class RouteValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (request.Route == null)
            {
                throw new BookingValidationException("Route must be built before booking.");
            }

            base.Handle(request);
        }
    }
}
