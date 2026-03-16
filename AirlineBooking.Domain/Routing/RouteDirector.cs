using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{

    public class RouteDirector
    {

        public Route BuildDirectRoute(IRouteBuilder builder, Flight flight)
        {
            builder.AddFlight(flight); 
            return builder.Build();   
        }
    }
}