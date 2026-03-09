using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public class ChildServiceFactory : IFlightServiceFactory
    {
        public Seat CreateSeat() => new Seat("Standard seat"); // можно тоже единый тип

        public Meal CreateMeal() => new Meal("Kids meal"); // специальная детская еда

        public Luggage CreateLuggage() => new Luggage(15); // меньше багаж для ребенка
    }
}