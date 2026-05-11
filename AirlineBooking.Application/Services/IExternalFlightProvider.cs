using AVIASALES.Domain.Entities;
using System.Collections.Generic;

namespace AVIASALES.Application.Services
{
    public interface IExternalFlightProvider
    {
        IReadOnlyList<Flight> GetFlights();
    }
}
