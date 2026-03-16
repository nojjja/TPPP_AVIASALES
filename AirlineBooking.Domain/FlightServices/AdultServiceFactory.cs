using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class AdultServiceFactory : IFlightServiceFactory
    {
        public Seat CreateSeat() => new Seat("Standard seat"); 

        public Meal CreateMeal() => new Meal("Adult meal"); 

        public Luggage CreateLuggage() => new Luggage(20); 
    }
}