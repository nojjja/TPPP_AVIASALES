using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Decorators
{
    public abstract class TicketDecorator : Ticket
    {
        protected readonly Ticket _decoratedTicket;

        protected TicketDecorator(Ticket ticket) : base(ticket.Flight)
        {
            _decoratedTicket = ticket;
        }

        public override decimal GetCost()
        {
            return _decoratedTicket.GetCost();
        }

        public override string GetFullDescription()
        {
            return _decoratedTicket.GetFullDescription();
        }
    }
}
