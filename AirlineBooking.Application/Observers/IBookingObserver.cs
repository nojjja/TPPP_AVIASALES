namespace AVIASALES.Application.Observers
{
    public interface IBookingObserver
    {
        void Update(BookingNotification notification);
    }
}
