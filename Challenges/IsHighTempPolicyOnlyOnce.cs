namespace Challenges
{
    public class IsHighTempPolicyOnlyOnce
    {
        public bool IsApplicable(Context context)
        {
            var maxTemp = context.Time.Date.Month switch
            {
                >= 2 and <= 4 => 2, //spring
                >= 5 and <= 7 => 3, // summer
                >= 8 and <= 10 => 4, // autumn
                _ => 1 // winter
            };

            return context.Temp >= maxTemp;
        }
    }
}
