namespace AVIASALES.Domain.Entities
{
    public class Luggage
    {
        public int WeightLimit { get; }

        public Luggage(int weightLimit)
        {
            WeightLimit = weightLimit;
        }
    }
}