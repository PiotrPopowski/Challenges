using Challenges.Entities;

namespace Challenges.PriceModifiers
{
    public interface IPriceModifier
    {
        PriceAdjustment GetPrice(Product product);
        bool IsApplicable();
    }
}
