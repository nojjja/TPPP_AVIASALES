using System.Collections.Generic;
using System.Windows;
using AVIASALES.Application.Observers;
using AVIASALES.Application.Services;
using AVIASALES.Domain.Entities;
using AVIASALES.UI.Decorators;

namespace AVIASALES
{
    public partial class AdminWindow : Window, IBookingObserver
    {
        private readonly BookingService _bookingService;
        private readonly List<string> _events;
        private readonly List<DisplayBookingDecorator> _bookings;

        public AdminWindow(BookingService bookingService)
        {
            _bookingService = bookingService;
            _events = new List<string>();
            _bookings = new List<DisplayBookingDecorator>();
            InitializeComponent();
            LoadHistory();
            LoadBookings();
            _bookingService.Attach(this);
        }

        public void Update(BookingNotification notification)
        {
            _events.Add(FormatNotification(notification));
            RefreshEvents();
            RefreshBookings();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            _bookingService.Detach(this);
            base.OnClosed(e);
        }

        private void LoadHistory()
        {
            foreach (var notification in _bookingService.GetNotificationHistory())
            {
                _events.Add(FormatNotification(notification));
            }

            RefreshEvents();
        }

        private void LoadBookings()
        {
            RefreshBookings();
        }

        private void RefreshEvents()
        {
            EventsListBox.ItemsSource = null;
            EventsListBox.ItemsSource = _events;
        }

        private void RefreshBookings()
        {
            _bookings.Clear();

            foreach (var booking in _bookingService.GetBookings())
            {
                _bookings.Add(new DisplayBookingDecorator(booking));
            }

            BookingsListBox.ItemsSource = null;
            BookingsListBox.ItemsSource = _bookings;
        }

        private string FormatNotification(BookingNotification notification)
        {
            return string.Format(
                "{0}: {1} | {2} | State {3} | Total {4}",
                notification.EventType,
                notification.Booking.PassengerName,
                notification.Booking.Flight.FlightNumber,
                notification.Booking.StateName,
                notification.Booking.TotalPrice);
        }

        private Booking GetSelectedBooking()
        {
            var selected = BookingsListBox.SelectedItem as DisplayBookingDecorator;
            if (selected == null)
            {
                MessageBox.Show("Select a booking first.");
                return null;
            }

            return selected.Booking;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyStateChange(delegate(Booking booking) { _bookingService.ConfirmBooking(booking); });
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyStateChange(delegate(Booking booking) { _bookingService.CompleteBooking(booking); });
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyStateChange(delegate(Booking booking) { _bookingService.CancelBooking(booking); });
        }

        private void ApplyStateChange(System.Action<Booking> changeAction)
        {
            var booking = GetSelectedBooking();
            if (booking == null)
            {
                return;
            }

            try
            {
                changeAction(booking);
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
