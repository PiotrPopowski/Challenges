using Challenges.Entities;
using System.Collections.ObjectModel;

namespace Challenges.PriceModifiers
{
    public class MembershipModifier : IPriceModifier
    {
        private readonly Membership _membership;
        private readonly ReadOnlyDictionary<Membership, Modifier> _modifiers;

        public MembershipModifier(Membership membership, ReadOnlyDictionary<Membership, Modifier> modifiers)
        {
            _membership = membership;
            _modifiers = modifiers;
        }

        public decimal GetPrice(Product product)
        {
            if (_modifiers.ContainsKey(_membership))
            {
                var modifier = _modifiers[_membership];
                var price = modifier.Sign == Sign.Multiply 
                    ? product.BasePrice * modifier.Value
                    : product.BasePrice + modifier.Value;

                return price;
            }

            return product.BasePrice;
        }

        public bool IsApplicable()
        {
            throw new NotImplementedException();
        }
    }
}
