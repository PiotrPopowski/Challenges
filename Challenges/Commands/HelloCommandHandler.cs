using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Commands
{
    internal class HelloCommandHandler : ICommandHandler
    {
        public string Execute(string[] args)
        {
            return $"Hello ${args.Aggregate((a, b) => $"{a} {b}")}";
        }
    }
}
