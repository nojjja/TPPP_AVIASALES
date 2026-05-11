using System.Collections.Generic;
using System.Linq;

namespace AVIASALES.Domain.Routing
{
    public class CompositeRoute : IRouteComponent
    {
        private readonly List<IRouteComponent> _segments = new List<IRouteComponent>();

        public void Add(IRouteComponent segment) => _segments.Add(segment);

        public string RouteSummary => string.Join(" → ", _segments.Select(s => s.RouteSummary));

        public double TotalDistance => _segments.Sum(s => s.TotalDistance);
    }
}
