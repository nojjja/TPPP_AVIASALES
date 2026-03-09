using System;

namespace AVIASALES.Domain.Entities
{
    public class Flight
    {
        public string FlightNumber { get; }
        public string From { get; }
        public string To { get; }
        public DateTime Departure { get; }
        public decimal BasePrice { get; }

        public Flight(string flightNumber, string from, string to, DateTime departure, decimal basePrice)
        {
            FlightNumber = flightNumber;
            From = from;
            To = to;
            Departure = departure;
            BasePrice = basePrice;
        }

        public override string ToString()
        {
            return $"{From} → {To} ({FlightNumber})";
        }
    }
}