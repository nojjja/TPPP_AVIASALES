using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{
    public class FlightSegment : IRouteComponent
    {
        private readonly Flight _flight;

        public FlightSegment(Flight flight)
        {
            _flight = flight;
        }

        public string RouteSummary => $"{_flight.From}→{_flight.To}";

        public double TotalDistance => _flight.Distance;
    }
}
