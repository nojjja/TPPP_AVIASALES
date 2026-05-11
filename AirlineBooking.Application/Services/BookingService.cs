using AVIASALES.Application.Interfaces;
using AVIASALES.Application.Observers;
using AVIASALES.Application.Validation;
using AVIASALES.Domain.Creators;
using AVIASALES.Domain.Decorators;
using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;
using AVIASALES.Domain.Pricing;
using AVIASALES.Domain.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVIASALES.Application.Services
{
    public class BookingService : IBookingSubject
    {
        private readonly IFlightProvider _flightProvider;
        private readonly IExternalFlightProvider _externalProvider;
        private readonly List<IBookingObserver> _observers;
        private readonly List<BookingNotification> _notifications;
        private readonly List<Booking> _bookings;

        public BookingService(IFlightProvider flightProvider, IExternalFlightProvider externalProvider = null)
        {
            if (flightProvider == null)
            {
                throw new ArgumentNullException("flightProvider");
            }

            _flightProvider = flightProvider;
            _externalProvider = externalProvider;
            _observers = new List<IBookingObserver>();
            _notifications = new List<BookingNotification>();
            _bookings = new List<Booking>();
        }

        public IReadOnlyList<Flight> GetAvailableFlights()
        {
            var flights = new List<Flight>(_flightProvider.GetFlights());

            if (_externalProvider != null)
            {
                flights.AddRange(_externalProvider.GetFlights());
            }

            return flights.AsReadOnly();
        }

        public Booking CreateBooking(string passengerName, string from, string to,
            string classType, bool isChild, bool hasBaggage, bool hasMeal)
        {
            var flight = GetAvailableFlights().FirstOrDefault(f => f.From == from && f.To == to);
            if (flight == null)
            {
                throw new ArgumentException("Flight not found");
            }

            var route = new Route();
            route.AddSegment(flight);

            return CreateBooking(passengerName, flight, route, classType, isChild, hasBaggage, hasMeal);
        }

        public Booking CreateBooking(string passengerName, Flight flight, IRouteComponent route,
            string classType, bool isChild, bool hasBaggage, bool hasMeal)
        {
            var request = new BookingRequest
            {
                PassengerName = passengerName,
                Flight = flight,
                Route = route,
                ClassType = classType,
                IsChild = isChild,
                HasBaggage = hasBaggage,
                HasMeal = hasMeal,
                ExistingBookings = _bookings.AsReadOnly()
            };

            BuildValidationChain(request).Handle(request);

            Ticket ticketOrder = CreateBaseTicket(flight, classType);

            if (hasBaggage)
            {
                ticketOrder = new BaggageDecorator(ticketOrder);
            }

            if (hasMeal)
            {
                ticketOrder = new MealDecorator(ticketOrder);
            }

            var pricingContext = new PricingContext(ResolvePricingStrategy(isChild));
            decimal totalPrice = pricingContext.CalculatePrice(ticketOrder);

            var booking = new Booking(passengerName, flight, route)
            {
                TotalPrice = totalPrice,
                Description = ticketOrder.GetFullDescription(),
                PricingPolicy = pricingContext.PolicyName,
                HasBaggage = hasBaggage,
                HasMeal = hasMeal
            };

            _bookings.Add(booking);
            Notify(new BookingNotification(booking, BookingEventType.Created));

            return booking;
        }

        public Booking CloneBooking(Booking originalBooking, string newPassengerName)
        {
            var clone = (Booking)originalBooking.Clone();
            clone.PassengerName = newPassengerName;
            _bookings.Add(clone);
            Notify(new BookingNotification(clone, BookingEventType.Cloned));
            return clone;
        }

        public IReadOnlyList<Booking> GetBookings()
        {
            return _bookings.AsReadOnly();
        }

        public IReadOnlyList<BookingNotification> GetNotificationHistory()
        {
            return _notifications.AsReadOnly();
        }

        public void ConfirmBooking(Booking booking)
        {
            ChangeBookingState(booking, delegate(Booking current) { current.Confirm(); });
        }

        public void CancelBooking(Booking booking)
        {
            ChangeBookingState(booking, delegate(Booking current) { current.Cancel(); });
        }

        public void CompleteBooking(Booking booking)
        {
            ChangeBookingState(booking, delegate(Booking current) { current.Complete(); });
        }

        public void Attach(IBookingObserver observer)
        {
            if (observer == null || _observers.Contains(observer))
            {
                return;
            }

            _observers.Add(observer);
        }

        public void Detach(IBookingObserver observer)
        {
            if (observer == null)
            {
                return;
            }

            _observers.Remove(observer);
        }

        public void Notify(BookingNotification notification)
        {
            _notifications.Add(notification);

            foreach (var observer in _observers)
            {
                observer.Update(notification);
            }
        }

        private void ChangeBookingState(Booking booking, Action<Booking> transition)
        {
            if (booking == null)
            {
                throw new ArgumentNullException("booking");
            }

            transition(booking);
            Notify(new BookingNotification(booking, BookingEventType.StateChanged));
        }

        private Ticket CreateBaseTicket(Flight flight, string classType)
        {
            switch (classType)
            {
                case "Business":
                    return new BusinessTicketCreator().CreateTicket(flight);
                case "First":
                    return new FirstClassTicketCreator().CreateTicket(flight);
                default:
                    return new EconomyTicketCreator().CreateTicket(flight);
            }
        }

        private IPricingStrategy ResolvePricingStrategy(bool isChild)
        {
            if (isChild)
            {
                return new ChildPricingStrategy();
            }

            return new StandardPricingStrategy();
        }

        private BookingValidationHandler BuildValidationChain(BookingRequest request)
        {
            var passengerHandler = new PassengerNameValidationHandler();
            var flightHandler = new FlightSelectionValidationHandler();
            var routeHandler = new RouteValidationHandler();
            var classHandler = new ClassSelectionValidationHandler();
            var departureHandler = new DepartureTimeValidationHandler();
            var duplicateHandler = new DuplicateBookingValidationHandler();

            passengerHandler.SetNext(flightHandler)
                .SetNext(routeHandler)
                .SetNext(classHandler)
                .SetNext(departureHandler)
                .SetNext(duplicateHandler);

            BookingValidationHandler tail = duplicateHandler;

            if (request.IsChild)
            {
                tail = tail.SetNext(new ChildCompositeRouteValidationHandler());
            }

            return passengerHandler;
        }
    }
}
