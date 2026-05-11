using AVIASALES.Domain.Routing;
using AVIASALES.Domain.States;
using System;

namespace AVIASALES.Domain.Entities
{
    public class Booking : ICloneable
    {
        public string PassengerName { get; set; }
        public Flight Flight { get; }
        public IRouteComponent Route { get; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public string PricingPolicy { get; set; }
        public bool HasBaggage { get; set; }
        public bool HasMeal { get; set; }
        private IBookingState _state;

        public Booking(string passengerName, Flight flight, IRouteComponent route)
        {
            PassengerName = passengerName;
            Flight = flight;
            Route = route;
            _state = new CreatedBookingState();
        }

        public string StateName
        {
            get { return _state.Name; }
        }

        public object Clone()
        {
            return new Booking(PassengerName, Flight, Route)
            {
                TotalPrice = TotalPrice,
                Description = Description,
                PricingPolicy = PricingPolicy,
                HasBaggage = HasBaggage,
                HasMeal = HasMeal
            };
        }

        public string SummaryText => Summary();

        public string Summary()
        {
            return string.Format(
                "{0}: {1} | {2} | Fare: {3} | State: {4} | Total: {5}",
                PassengerName,
                Route.RouteSummary,
                Description,
                PricingPolicy,
                StateName,
                TotalPrice);
        }

        public void Confirm()
        {
            _state.Confirm(this);
        }

        public void Cancel()
        {
            _state.Cancel(this);
        }

        public void Complete()
        {
            _state.Complete(this);
        }

        public void TransitionTo(IBookingState state)
        {
            _state = state;
        }

        public override string ToString()
        {
            return SummaryText;
        }
    }
}
