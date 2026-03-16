using AirlineBooking.Domain.Entities;
using AirlineBooking.Domain.Entities.Tickets;
using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class AdultServiceFactory : IFlightServiceFactory
    {
        public ISeat CreateSeat() => new AdultSeat();
        public IMeal CreateMeal() => new AdultMeal();
        public ILuggage CreateLuggage() => new AdultLuggage();
    }
}