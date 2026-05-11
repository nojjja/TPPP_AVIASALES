namespace AVIASALES.Application.Observers
{
    public interface IBookingSubject
    {
        void Attach(IBookingObserver observer);
        void Detach(IBookingObserver observer);
        void Notify(BookingNotification notification);
    }
}
