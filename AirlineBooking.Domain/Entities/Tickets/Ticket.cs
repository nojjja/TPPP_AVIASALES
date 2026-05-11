using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Entities.Tickets
{
    public abstract class Ticket
    {
        public Flight Flight { get; }
        public decimal Price { get; protected set; }
        public string ClassType { get; protected set; }

        protected Ticket(Flight flight)
        {
            Flight = flight;
        }

        public virtual decimal GetCost()
        {
            return Price;
        }

        public virtual string GetFullDescription()
        {
            return string.Format("{0} ticket for flight {1}-{2}", ClassType, Flight.From, Flight.To);
        }

        public override string ToString()
        {
            return string.Format(
                "{0} | {1} -> {2} | Price: {3}",
                ClassType,
                Flight.From,
                Flight.To,
                GetCost());
        }
    }
}
