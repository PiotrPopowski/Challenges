namespace Challenges.PriceModifiers
{
    public class Modifier
    {
        public decimal Value { get; set; }
        public Sign Sign { get; set; }
    }

    public enum Sign
    {
        Multiply,
        Add
    }
}
