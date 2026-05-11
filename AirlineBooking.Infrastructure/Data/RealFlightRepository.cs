using AVIASALES.Application.Interfaces;
using AVIASALES.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AVIASALES.Infrastructure.Data
{
    public class RealFlightRepository : IFlightProvider
    {
        private readonly List<Flight> _flights;

        public RealFlightRepository()
        {
            _flights = new List<Flight>
            {
                new Flight("SU100", "Moscow", "Paris", DateTime.Now.AddHours(5), 200m, 2485),
                new Flight("AF200", "Paris", "London", DateTime.Now.AddHours(8), 150m, 344),
                new Flight("BA300", "London", "New York", DateTime.Now.AddHours(10), 400m, 5570)
            };
        }

        public IReadOnlyList<Flight> GetFlights()
        {
            return _flights.AsReadOnly();
        }
    }
}
