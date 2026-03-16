using AVIASALES.Domain.Entities;

namespace AVIASALES.Domain.FlightServices
{
    public interface IFlightServiceFactory
    {
        ISeat CreateSeat();
        IMeal CreateMeal();
        ILuggage CreateLuggage();
    }
}