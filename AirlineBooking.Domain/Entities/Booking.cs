using AVIASALES.Domain.Entities.Tickets;
using System;
using System.Linq;

namespace AVIASALES.Domain.Entities
{
    public class Booking : ICloneable
    {
        public string PassengerName { get; set; }

        public Ticket Ticket { get; }
        public Route Route { get; }

        public Seat Seat { get; set; }
        public Meal Meal { get; set; }
        public Luggage Luggage { get; set; }

        public bool HasBaggage { get; set; }
        public bool HasMeal { get; set; }

        public Booking(string passengerName, Ticket ticket, Route route)
        {
            PassengerName = passengerName;
            Ticket = ticket;
            Route = route;
        }

        public Booking Clone()
        {
            return new Booking(PassengerName, Ticket, Route)  // shallow copy
            {
                Seat = this.Seat,
                Meal = this.Meal,
                Luggage = this.Luggage,
                HasBaggage = this.HasBaggage,
                HasMeal = this.HasMeal
            };
        }

  
        object ICloneable.Clone() => Clone();

 
        public string Summary()
        {
            var firstFlight = Route.Segments.FirstOrDefault();
            string routeInfo = firstFlight != null ? $"{firstFlight.From} → {firstFlight.To}" : "Нет маршрута";

            string services = "";
            if (HasBaggage && Luggage != null) services += $"Baggage: {Luggage.WeightLimit}kg ";
            if (HasMeal && Meal != null) services += $"Meal: {Meal.Name} ";
            if (Seat != null) services += $"Seat: {Seat.Type} ";

            return $"{PassengerName} | {routeInfo} | {services}";
        }
    }
}