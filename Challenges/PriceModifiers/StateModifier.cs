using Challenges.Entities;
using System.Collections.ObjectModel;

namespace Challenges.PriceModifiers
{
    public class StateModifier : IPriceModifier
    {
        private readonly State _state;
        private readonly ReadOnlyDictionary<State, Modifier> _modifiers;

        public StateModifier(State state, ReadOnlyDictionary<State, Modifier> modifiers)
        {
            _state = state;
            _modifiers = modifiers;
        }

        public PriceAdjustment GetPrice(Product product)
        {
            var adjustment = new PriceAdjustment() 
            { 
                Price = product.BasePrice, 
                Type = AdjustmentType.State 
            };

            if (_modifiers.ContainsKey(_state))
            {
                var modifier = _modifiers[_state];
                adjustment.Price = modifier.Sign == Sign.Multiply 
                    ? product.BasePrice * modifier.Value 
                    : product.BasePrice + modifier.Value;
            }

            return adjustment;
        }

        public bool IsApplicable()
        {
            throw new NotImplementedException();
        }
    }
}
