using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Entities.Tickets
{
    public class BusinessTicket : Ticket
    {
        public BusinessTicket(Flight flight) : base(flight)
        {
            ClassType = "Business";
            Price = flight.BasePrice * 2;
        }
    }
}