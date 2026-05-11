using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Pricing
{
    public class ChildPricingStrategy : IPricingStrategy
    {
        private const decimal ChildDiscount = 0.8m;

        public string PolicyName
        {
            get { return "Child discount"; }
        }

        public decimal CalculatePrice(Ticket ticket)
        {
            return ticket.GetCost() * ChildDiscount;
        }
    }
}
