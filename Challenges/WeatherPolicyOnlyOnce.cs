using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class WeatherPolicyOnlyOnce
    {
        private static IsWindyPolicyOnlyOnce windyPolicy = new();
        private static IsHighTempPolicyOnlyOnce tempPolicy = new();

        public bool IsApplicable(Context context)
        {
            return windyPolicy.IsApplicable(context) && tempPolicy.IsApplicable(context);
        }
    }
}
