using AVIASALES.Application.Interfaces;
using AVIASALES.Domain.Entities;
using AVIASALES.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace AVIASALES.Infrastructure.Proxies
{
    public class FlightRepositoryProxy : IFlightProvider
    {
        private const string AdminUserName = "admin";
        private const string AdminPassword = "admin123";
        private readonly RealFlightRepository _realRepository;
        private List<Flight> _cache;
        private bool _isAdminAuthorized;

        public FlightRepositoryProxy()
        {
            _realRepository = new RealFlightRepository();
        }

        public IReadOnlyList<Flight> GetFlights()
        {
            Console.WriteLine("[LOG] " + DateTime.Now + ": flight list requested through proxy.");

            if (_cache == null)
            {
                Console.WriteLine("[LOG] Cache is empty. Loading flights from real repository.");
                _cache = new List<Flight>(_realRepository.GetFlights());
            }
            else
            {
                Console.WriteLine("[LOG] Returning flights from cache.");
            }

            return _cache.AsReadOnly();
        }

        public bool CanAccessAdminPanel()
        {
            return _isAdminAuthorized;
        }

        public bool TryAuthorizeAdmin(string userName, string password)
        {
            _isAdminAuthorized = userName == AdminUserName && password == AdminPassword;
            return _isAdminAuthorized;
        }

        public void ResetAdminAccess()
        {
            _isAdminAuthorized = false;
        }
    }
}
