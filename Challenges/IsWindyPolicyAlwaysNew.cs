using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class IsWindyPolicyAlwaysNew
    {
        private readonly double _windMPS;

        public IsWindyPolicyAlwaysNew(double windMPS)
        {
            _windMPS = windMPS;
        }

        public bool IsApplicable()
        {
            if (_windMPS >= 5) return true;
            else return false;
        }
    }
}
