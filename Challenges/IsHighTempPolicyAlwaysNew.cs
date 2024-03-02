namespace Challenges
{
    public class IsHighTempPolicyAlwaysNew
    {
        private readonly double _temp;
        private readonly DateTime _time;

        public IsHighTempPolicyAlwaysNew(double temp, DateTime time)
        {
            _temp = temp;
            _time = time;
        }

        public bool IsApplicable()
        {
            var maxTemp = _time.Date.Month switch
            {
                >= 2 and <= 4 => 2, //spring
                >= 5 and <= 7 => 3, // summer
                >= 8 and <= 10 => 4, // autumn
                _ => 1 // winter
            };

            return _temp >= maxTemp;
        }
    }
}
