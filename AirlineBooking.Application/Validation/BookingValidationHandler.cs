namespace AVIASALES.Application.Validation
{
    public abstract class BookingValidationHandler
    {
        private BookingValidationHandler _next;

        public BookingValidationHandler SetNext(BookingValidationHandler next)
        {
            _next = next;
            return next;
        }

        public virtual void Handle(BookingRequest request)
        {
            if (_next != null)
            {
                _next.Handle(request);
            }
        }
    }
}
