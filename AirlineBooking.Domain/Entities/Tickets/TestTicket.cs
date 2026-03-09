using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.Entities.Tickets
{
    public class TestTicket : Ticket
    {
        public TestTicket(Flight flight) : base(flight)
        {
            ClassType = "Test";
            Price = flight.BasePrice * 5;
        }
    }
}