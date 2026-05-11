using AVIASALES.Domain.Entities;
using System.Collections.Generic;

namespace AVIASALES.Application.Interfaces
{
    public interface IFlightProvider
    {
        IReadOnlyList<Flight> GetFlights();
    }
}
