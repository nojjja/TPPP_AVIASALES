using AVIASALES.Application.Services;
using AVIASALES.Domain.Entities;
using AVIASALES.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace AVIASALES.Infrastructure.Adapters
{
    public class AmadeusServiceAdapter : IExternalFlightProvider
    {
        public IReadOnlyList<Flight> GetFlights()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "amadeus-flights.json");
            if (!File.Exists(filePath))
            {
                return new List<Flight>().AsReadOnly();
            }

            List<AmadeusFlightRecord> externalFlights;
            var serializer = new DataContractJsonSerializer(typeof(List<AmadeusFlightRecord>));

            using (var stream = File.OpenRead(filePath))
            {
                externalFlights = (List<AmadeusFlightRecord>)serializer.ReadObject(stream);
            }

            var flights = new List<Flight>();
            for (int i = 0; i < externalFlights.Count; i++)
            {
                var item = externalFlights[i];
                DateTime departure = DateTime.Parse(item.DepartureDate);
                string flightNumber = string.Format("{0}{1:D3}", item.AirlineCode, i + 1);

                flights.Add(new Flight(
                    flightNumber,
                    item.Origin,
                    item.Destination,
                    departure,
                    item.PriceEur,
                    item.Distance));
            }

            return flights.AsReadOnly();
        }
    }
}
