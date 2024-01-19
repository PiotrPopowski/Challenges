using Challenges.Entities;
using Challenges.PriceModifiers;

namespace Challenges
{
    public class PriceCalculator
    {
        private readonly List<IPriceModifier> _priceModifiers;

        public PriceCalculator(IPriceModifierProvider priceModifierProvider)
        {
            _priceModifiers = priceModifierProvider.GetModifiers();
        }

        public decimal Calculate(Product product, State state, Membership membership, int age)
        {
            var adjustments = new List<PriceAdjustment>();

            foreach (var modifier in _priceModifiers)
            {
               adjustments.Add(modifier.GetPrice(product));
            }

            if(adjustmentsContainsMultipleMemberships(adjustments))
            {
                var toRemove = adjustments
                                .Where(x => x.Type == AdjustmentType.Membership)
                                .OrderBy(x => x.Price)
                                .Skip(1)
                                .ToList();
                toRemove.ForEach(a => adjustments.Remove(a));
            }

            var finalPrize = adjustments.Sum(adjustment => adjustment.Price);

            return finalPrize;

            bool adjustmentsContainsMultipleMemberships(List<PriceAdjustment> adjustments) 
                => adjustments.Count(x => x.Type == AdjustmentType.Membership) > 1;
        }
    }
}
