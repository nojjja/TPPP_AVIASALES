using System.Collections.Generic;
using System.Linq;

namespace AVIASALES.Domain.Entities
{
    public class Route
    {
        private readonly List<Flight> _segments = new List<Flight>();
        public IReadOnlyList<Flight> Segments => _segments.AsReadOnly();

        public bool IsRoundTrip { get; private set; }


        public void AddSegment(Flight flight) => _segments.Add(flight);


        public void SetRoundTrip(bool value) => IsRoundTrip = value;


        public void MarkAsRoundTrip() => IsRoundTrip = true;


        public string RouteSummary()
        {
            if (!_segments.Any()) return "Маршрут не задан";

            var routeStr = string.Join(" → ", _segments.Select(f => $"{f.From}→{f.To}"));

            if (IsRoundTrip)
                routeStr += " (RoundTrip)";

            return routeStr;
        }


        public string From => _segments.FirstOrDefault()?.From ?? "";


        public string To => _segments.LastOrDefault()?.To ?? "";
    }
}