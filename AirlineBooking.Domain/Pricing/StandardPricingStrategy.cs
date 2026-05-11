using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Pricing
{
    public class StandardPricingStrategy : IPricingStrategy
    {
        public string PolicyName
        {
            get { return "Standard fare"; }
        }

        public decimal CalculatePrice(Ticket ticket)
        {
            return ticket.GetCost();
        }
    }
}
