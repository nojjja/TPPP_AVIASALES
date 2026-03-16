using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class ChildServiceFactory : IFlightServiceFactory
    {
        public Seat CreateSeat() => new Seat("Standard seat"); 

        public Meal CreateMeal() => new Meal("Kids meal"); 

        public Luggage CreateLuggage() => new Luggage(15); 
    }
}