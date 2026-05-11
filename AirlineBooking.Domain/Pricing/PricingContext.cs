using System;
using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Pricing
{
    public class PricingContext
    {
        private readonly IPricingStrategy _strategy;

        public PricingContext(IPricingStrategy strategy)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            _strategy = strategy;
        }

        public decimal CalculatePrice(Ticket ticket)
        {
            return _strategy.CalculatePrice(ticket);
        }

        public string PolicyName
        {
            get { return _strategy.PolicyName; }
        }
    }
}
