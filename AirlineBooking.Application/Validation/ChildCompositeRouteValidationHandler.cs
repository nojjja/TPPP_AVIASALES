using AVIASALES.Domain.Routing;

namespace AVIASALES.Application.Validation
{
    public class ChildCompositeRouteValidationHandler : BookingValidationHandler
    {
        public override void Handle(BookingRequest request)
        {
            if (request.IsChild && request.Route is CompositeRoute)
            {
                throw new BookingValidationException("Child booking is currently available only for direct flights.");
            }

            base.Handle(request);
        }
    }
}
