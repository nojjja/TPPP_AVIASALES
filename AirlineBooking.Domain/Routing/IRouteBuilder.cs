using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Routing
{
    public interface IRouteBuilder
    {
        void AddFlight(Flight flight);
        Route Build();
    }
}