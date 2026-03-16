using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AVIASALES
{
    public partial class MainWindow : Window
    {
        private readonly BookingService _bookingService;
        private readonly List<Booking> _bookings;

        public MainWindow()
        {
            InitializeComponent();
            _bookingService = new BookingService();
            _bookings = new List<Booking>();

            LoadFlights();
        }

        private void LoadFlights()
        {
           
            FlightsComboBox.ItemsSource = _bookingService.GetAvailableFlights();
            FlightsComboBox.DisplayMemberPath = "RouteSummary"; 
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите рейс");
                return;
            }

            if (ClassComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите класс");
                return;
            }

            if (string.IsNullOrWhiteSpace(PassengerTextBox.Text))
            {
                MessageBox.Show("Введите имя пассажира");
                return;
            }

            var selectedFlight = (Flight)FlightsComboBox.SelectedItem;
            var selectedClass = ((ComboBoxItem)ClassComboBox.SelectedItem).Content.ToString();
            bool hasBaggage = BaggageCheckBox.IsChecked ?? false;
            bool hasMeal = MealCheckBox.IsChecked ?? false;
            bool isChild = IsChildCheckBox.IsChecked ?? false; 

            var booking = _bookingService.CreateBooking(
                PassengerTextBox.Text,
                selectedFlight.From,
                selectedFlight.To,
                selectedClass,
                isChild 
            );

            booking.HasBaggage = hasBaggage;
            booking.HasMeal = hasMeal;

            _bookings.Add(booking);
            RefreshBookingList();

            MessageBox.Show("Бронирование создано!\n" + booking.Summary());
        }

        private void CloneBookingButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsListBox.SelectedItem is Booking selected)
            {
                var clone = _bookingService.CloneBooking(selected, selected.PassengerName + " Copy");
                _bookings.Add(clone);
                RefreshBookingList();
            }
        }

        private void RefreshBookingList()
        {
            BookingsListBox.ItemsSource = null;
            BookingsListBox.ItemsSource = _bookings;
        }
    }
}