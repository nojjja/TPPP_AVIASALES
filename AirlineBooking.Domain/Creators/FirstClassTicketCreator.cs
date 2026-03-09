using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Creators
{
    public class FirstClassTicketCreator : TicketCreator
    {
        public override Ticket CreateTicket(Flight flight)
        {
            return new FirstClassTicket(flight);
        }
    }
}