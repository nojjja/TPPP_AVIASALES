using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Decorators
{
    public class BaggageDecorator : TicketDecorator
    {
        public BaggageDecorator(Ticket ticket) : base(ticket)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 20.0m;
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + ", with baggage";
        }
    }
}
