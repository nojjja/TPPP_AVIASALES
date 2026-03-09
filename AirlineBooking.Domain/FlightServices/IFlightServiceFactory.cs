using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public interface IFlightServiceFactory
    {
        Seat CreateSeat();
        Meal CreateMeal();
        Luggage CreateLuggage();
    }
}