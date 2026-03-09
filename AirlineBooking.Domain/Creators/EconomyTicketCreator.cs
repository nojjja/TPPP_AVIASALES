using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Creators
{
    public class EconomyTicketCreator : TicketCreator
    {
        public override Ticket CreateTicket(Flight flight)
        {
            return new EconomyTicket(flight);
        }
    }
}