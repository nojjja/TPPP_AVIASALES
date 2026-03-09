using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Entities.Tickets
{
    public class FirstClassTicket : Ticket
    {
        public FirstClassTicket(Flight flight) : base(flight)
        {
            ClassType = "First";
            Price = flight.BasePrice * 3;
        }
    }
}