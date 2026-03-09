using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Creators
{
    public class BusinessTicketCreator : TicketCreator
    {
        public override Ticket CreateTicket(Flight flight)
        {
            return new BusinessTicket(flight);
        }
    }
}