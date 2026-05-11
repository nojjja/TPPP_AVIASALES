using AVIASALES.Domain.Entities.Tickets;

namespace AVIASALES.Domain.Pricing
{
    public interface IPricingStrategy
    {
        decimal CalculatePrice(Ticket ticket);
        string PolicyName { get; }
    }
}
