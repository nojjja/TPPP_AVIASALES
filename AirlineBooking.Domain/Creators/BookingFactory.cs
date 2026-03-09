using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;
using System;

namespace AVIASALES.Domain.Factories
{
    // Фабрика для создания билета и маршрута
    public class BookingFactory
    {
        // Создаёт маршрут (Route) с одним рейсом
        public Route CreateRoute(Flight flight)
        {
            var route = new Route();
            route.AddSegment(flight);
            return route;
        }

        // Создаёт билет нужного класса для рейса
        public Ticket CreateTicket(Flight flight, string classType)
        {
            switch (classType)
            {
                case "Economy":
                    return new EconomyTicket(flight);

                case "Business":
                    return new BusinessTicket(flight);

                case "First":
                    return new FirstClassTicket(flight);

                default:
                    throw new ArgumentException("Unknown ticket class");
            }
        }
    }
}