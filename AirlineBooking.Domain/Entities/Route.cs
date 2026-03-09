using System.Collections.Generic;
using System.Linq;

namespace AVIASALES.Domain.Entities
{
    public class Route
    {
        private readonly List<Flight> _segments = new List<Flight>();
        public IReadOnlyList<Flight> Segments => _segments.AsReadOnly();

        // Флаг, указывающий, является ли маршрут туда-обратно
        public bool IsRoundTrip { get; private set; }

        // Добавляет рейс в маршрут
        public void AddSegment(Flight flight) => _segments.Add(flight);

        // Устанавливает значение round trip
        public void SetRoundTrip(bool value) => IsRoundTrip = value;

        // Помечает маршрут как туда-обратно
        public void MarkAsRoundTrip() => IsRoundTrip = true;

        // Формирует строку маршрута для отображения в UI
        public string RouteSummary()
        {
            if (!_segments.Any()) return "Маршрут не задан";

            var routeStr = string.Join(" → ", _segments.Select(f => $"{f.From}→{f.To}"));

            if (IsRoundTrip)
                routeStr += " (RoundTrip)";

            return routeStr;
        }

        // Город отправления (первый сегмент)
        public string From => _segments.FirstOrDefault()?.From ?? "";

        // Город назначения (последний сегмент)
        public string To => _segments.LastOrDefault()?.To ?? "";
    }
}