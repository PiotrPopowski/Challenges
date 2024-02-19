using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    internal class ActionRunner
    {
        public async Task Run()
        {
            await Task.Run(() => { Console.WriteLine("Mrs Hi"); });
            Console.WriteLine("Hello");
        }
    }
}
