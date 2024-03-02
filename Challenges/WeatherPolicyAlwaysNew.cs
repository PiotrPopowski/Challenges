using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class WeatherPolicyAlwaysNew
    {
        private IsHighTempPolicyAlwaysNew tempPolicy;
        private IsWindyPolicyAlwaysNew windyPolicy;

        public WeatherPolicyAlwaysNew(double wind, double temp, DateTime date)
        {
            tempPolicy = new IsHighTempPolicyAlwaysNew(temp, date);
            windyPolicy = new IsWindyPolicyAlwaysNew(wind);
        }

        public bool IsApplicable()
        {
            return tempPolicy.IsApplicable() && windyPolicy.IsApplicable();
        }
    }
}
