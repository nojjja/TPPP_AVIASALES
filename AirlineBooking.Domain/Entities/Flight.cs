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
        public double Distance { get; set; }

        public Flight(string flightNumber, string from, string to, DateTime departure, decimal basePrice, double distance)
        {
            FlightNumber = flightNumber;
            From = from;
            To = to;
            Departure = departure;
            BasePrice = basePrice;
            Distance = distance;
        }

        public override string ToString() => $"{From} → {To} ({FlightNumber})";
    }
}