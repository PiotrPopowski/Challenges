using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class IsWindyPolicyOnlyOnce
    {
        public bool IsApplicable(Context context)
        {
            if (context.WindMPS >= 5) return true;
            else return false;
        }
    }
}
