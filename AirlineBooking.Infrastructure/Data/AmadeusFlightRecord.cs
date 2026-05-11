using System.Runtime.Serialization;

namespace AVIASALES.Infrastructure.Data
{
    [DataContract]
    public class AmadeusFlightRecord
    {
        [DataMember(Name = "origin")]
        public string Origin { get; set; }

        [DataMember(Name = "destination")]
        public string Destination { get; set; }

        [DataMember(Name = "price_eur")]
        public decimal PriceEur { get; set; }

        [DataMember(Name = "departure_date")]
        public string DepartureDate { get; set; }

        [DataMember(Name = "airline_code")]
        public string AirlineCode { get; set; }

        [DataMember(Name = "distance")]
        public double Distance { get; set; }
    }
}
