using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AVIASALES.Application.Observers;
using AVIASALES.Application.Services;
using AVIASALES.Application.Validation;
using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Routing;
using AVIASALES.Infrastructure.Adapters;
using AVIASALES.Infrastructure.Observers;
using AVIASALES.Infrastructure.Proxies;
using AVIASALES.UI.Commands;
using AVIASALES.UI.Decorators;

namespace AVIASALES
{
    public partial class MainWindow : Window, IBookingObserver
    {
        private readonly BookingService _bookingService;
        private readonly FlightRepositoryProxy _flightProxy;
        private readonly List<DisplayBookingDecorator> _bookings;
        private readonly BookingAuditObserver _auditObserver;
        public ICommand BookFlightCommand { get; private set; }
        public ICommand CloneBookingCommand { get; private set; }
        public ICommand OpenAdminPanelCommand { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            _flightProxy = new FlightRepositoryProxy();
            var amadeusAdapter = new AmadeusServiceAdapter();
            _bookingService = new BookingService(_flightProxy, amadeusAdapter);
            _bookings = new List<DisplayBookingDecorator>();
            _auditObserver = new BookingAuditObserver();
            _bookingService.Attach(this);
            _bookingService.Attach(_auditObserver);
            BookFlightCommand = new BookFlightCommand(this);
            CloneBookingCommand = new CloneBookingCommand(this);
            OpenAdminPanelCommand = new OpenAdminPanelCommand(this);
            DataContext = this;

            LoadFlights();
        }

        private void LoadFlights()
        {
            FlightsComboBox.ItemsSource = _bookingService.GetAvailableFlights();
            FlightsComboBox.DisplayMemberPath = "FlightNumber";
        }

        public bool CanBookFlight()
        {
            return FlightsComboBox != null &&
                   ClassComboBox != null &&
                   PassengerTextBox != null;
        }

        public void BookFlight()
        {
            try
            {
                var selectedFlight = FlightsComboBox.SelectedItem as Flight;
                var selectedClassItem = ClassComboBox.SelectedItem as ComboBoxItem;
                string selectedClass = selectedClassItem != null
                    ? selectedClassItem.Content.ToString()
                    : null;
                bool hasBaggage = BaggageCheckBox.IsChecked ?? false;
                bool hasMeal = MealCheckBox.IsChecked ?? false;
                bool isChild = IsChildCheckBox.IsChecked ?? false;
                var route = selectedFlight != null ? BuildRoute(selectedFlight) : null;

                var booking = _bookingService.CreateBooking(
                    PassengerTextBox.Text,
                    selectedFlight,
                    route,
                    selectedClass,
                    isChild,
                    hasBaggage,
                    hasMeal
                );

                MessageBox.Show("Booking created.\n" + booking.Summary());
            }
            catch (BookingValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CanCloneBooking()
        {
            return BookingsListBox != null && BookingsListBox.SelectedItem is DisplayBookingDecorator;
        }

        public void CloneSelectedBooking()
        {
            var selected = BookingsListBox.SelectedItem as DisplayBookingDecorator;
            if (selected != null)
            {
                _bookingService.CloneBooking(selected.Booking, selected.Booking.PassengerName + " Copy");
            }
        }

        public void OpenAdminPanel()
        {
            if (!_flightProxy.CanAccessAdminPanel())
            {
                var loginWindow = new AdminLoginWindow();
                loginWindow.Owner = this;

                bool? result = loginWindow.ShowDialog();
                if (result != true)
                {
                    return;
                }

                if (!_flightProxy.TryAuthorizeAdmin(loginWindow.UserName, loginWindow.Password))
                {
                    MessageBox.Show("Access denied. Invalid administrator credentials.");
                    return;
                }
            }

            var adminWindow = new AdminWindow(_bookingService);
            adminWindow.Owner = this;
            adminWindow.ShowDialog();
        }

        private void BookingInputChanged(object sender, RoutedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private void BookingsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private void RefreshBookingList()
        {
            BookingsListBox.ItemsSource = null;
            BookingsListBox.ItemsSource = _bookings;
            CommandManager.InvalidateRequerySuggested();
        }

        public void Update(BookingNotification notification)
        {
            if (notification.EventType == BookingEventType.Created ||
                notification.EventType == BookingEventType.Cloned)
            {
                _bookings.Add(new DisplayBookingDecorator(notification.Booking));
            }

            RefreshBookingList();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            _bookingService.Detach(this);
            _bookingService.Detach(_auditObserver);
            base.OnClosed(e);
        }

        private IRouteComponent BuildRoute(Flight selectedFlight)
        {
            var connectingFlight = _bookingService
                .GetAvailableFlights()
                .FirstOrDefault(f =>
                    f.FlightNumber != selectedFlight.FlightNumber &&
                    f.From == selectedFlight.To);

            if (connectingFlight == null)
            {
                return new FlightSegment(selectedFlight);
            }

            var compositeRoute = new CompositeRoute();
            compositeRoute.Add(new FlightSegment(selectedFlight));
            compositeRoute.Add(new FlightSegment(connectingFlight));

            return compositeRoute;
        }
    }
}
