using AVIASALES.Domain.Entities;
using AVIASALES.Domain.Routing;
using System.Collections.Generic;

namespace AVIASALES.Application.Validation
{
    public class BookingRequest
    {
        public string PassengerName { get; set; }
        public Flight Flight { get; set; }
        public IRouteComponent Route { get; set; }
        public string ClassType { get; set; }
        public bool IsChild { get; set; }
        public bool HasBaggage { get; set; }
        public bool HasMeal { get; set; }
        public IReadOnlyList<Booking> ExistingBookings { get; set; }
    }
}
