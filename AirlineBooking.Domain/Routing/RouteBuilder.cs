using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{
    public class RouteBuilder : IRouteBuilder
    {
        private Route _route = new Route();
        public void AddFlight(Flight flight)
        {
            _route.AddSegment(flight);
        }

        public Route Build()
        {
            return _route;
        }
    }
}