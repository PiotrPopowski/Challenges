using Challenges.PriceModifiers;

namespace Challenges
{
    public interface IPriceModifierProvider
    {
        List<IPriceModifier> GetModifiers();
    }
}