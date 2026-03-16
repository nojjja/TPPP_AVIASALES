using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;
using System;

namespace AVIASALES.Domain.Factories
{
    public class BookingFactory
    {
        public Route CreateRoute(Flight flight)
        {
            var route = new Route();
            route.AddSegment(flight);
            return route;
        }

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