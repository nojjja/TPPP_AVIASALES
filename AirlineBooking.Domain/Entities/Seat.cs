namespace AVIASALES.Domain.Entities
{
    public class Seat
    {
        public string Type { get; }

        public Seat(string type)
        {
            Type = type;
        }
    }
}