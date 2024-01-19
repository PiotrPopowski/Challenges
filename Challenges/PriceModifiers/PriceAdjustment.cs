namespace Challenges.PriceModifiers
{
    public class PriceAdjustment
    {
        public decimal Price { get; set; }
        public AdjustmentType Type { get; set; }
    }

    public enum AdjustmentType
    {
        Membership = 0,
        State,
        Age
    }
}
