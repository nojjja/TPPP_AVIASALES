using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Entities.Tickets
{
    public class EconomyTicket : Ticket
    {
        public EconomyTicket(Flight flight) : base(flight)
        {
            ClassType = "Economy";
            Price = flight.BasePrice;
        }
    }
}