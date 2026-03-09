using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class AdultServiceFactory : IFlightServiceFactory
    {
        public Seat CreateSeat() => new Seat("Standard seat"); // можно единый тип для взрослых

        public Meal CreateMeal() => new Meal("Adult meal"); // полноценная еда для взрослого

        public Luggage CreateLuggage() => new Luggage(20); // стандартный багаж
    }
}