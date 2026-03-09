using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Creators
{
    public abstract class TicketCreator
    {
        public abstract Ticket CreateTicket(Flight flight);
    }
}