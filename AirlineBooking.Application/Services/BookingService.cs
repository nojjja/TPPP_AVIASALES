using AVIASALES.Domain.Creators;
using AVIASALES.Domain.Entities;
using AVIASALES.Domain.FlightServices;
using AVIASALES.Domain.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVIASALES.Domain.Services
{
    public class BookingService
    {
        private readonly FlightRepository _repository;

        public BookingService()
        {
            _repository = FlightRepository.Instance; 
        }


        public IReadOnlyList<Flight> GetAvailableFlights()
        {
            return _repository.Flights.AsReadOnly();
        }

        public Booking CreateBooking(
            string passengerName,
            string from,
            string to,
            string classType,
            bool isChild)  
        {

            var flight = _repository.Flights.FirstOrDefault(f => f.From == from && f.To == to);
            if (flight == null)
                throw new ArgumentException("Рейс не найден");

            TicketCreator creator;
            if (classType == "Economy")
                creator = new EconomyTicketCreator();
            else if (classType == "Business")
                creator = new BusinessTicketCreator();
            else if (classType == "First")
                creator = new FirstClassTicketCreator();
            else
                throw new ArgumentException("Неизвестный класс билета");

            var ticket = creator.CreateTicket(flight);

     
            var builder = new RouteBuilder();
            var director = new RouteDirector();
            var route = director.BuildDirectRoute(builder, flight);

    
            IFlightServiceFactory serviceFactory = isChild
                ? (IFlightServiceFactory)new ChildServiceFactory()
                : new AdultServiceFactory();

            var seat = serviceFactory.CreateSeat();
            var meal = serviceFactory.CreateMeal();
            var luggage = serviceFactory.CreateLuggage();


            var booking = new Booking(passengerName, ticket, route)
            {
                Seat = seat,
                Meal = meal,
                Luggage = luggage
            };

            return booking;
        }


        public Booking CloneBooking(Booking originalBooking, string newPassengerName)
        {
            var cloned = (Booking)originalBooking.Clone();
            cloned.PassengerName = newPassengerName;
            return cloned;
        }
    }
}