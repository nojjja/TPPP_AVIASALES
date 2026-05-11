using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Decorators
{
    public class MealDecorator : TicketDecorator
    {
        public MealDecorator(Ticket ticket) : base(ticket)
        {
        }

        public override decimal GetCost()
        {
            return base.GetCost() + 15.0m;
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + ", hot meal";
        }
    }
}
