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

        public override string ToString()
        {
            return $"{ClassType} ticket | {Flight.From} → {Flight.To} | Price: {Price}";
        }
    }
}