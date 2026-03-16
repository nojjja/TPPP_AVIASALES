using AirlineBooking.Domain.Entities;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class ChildServiceFactory : IFlightServiceFactory
    {
        public ISeat CreateSeat() => new ChildSeat();       
        public IMeal CreateMeal() => new ChildMeal();       
        public ILuggage CreateLuggage() => new ChildLuggage(); 
    }
}