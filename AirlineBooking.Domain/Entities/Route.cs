using System.Collections.Generic;
using System.Linq;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{
    public class Route : IRouteComponent
    {
        private readonly List<Flight> _segments = new List<Flight>();

        public IReadOnlyList<Flight> Segments => _segments.AsReadOnly();

        public void AddSegment(Flight flight) => _segments.Add(flight);

        public string RouteSummary => _segments.Count == 0 ? "Маршрут не задан" :
            string.Join(" → ", _segments.Select(f => $"{f.From}→{f.To}"));

        public double TotalDistance => _segments.Sum(f => f.Distance);
    }
}
