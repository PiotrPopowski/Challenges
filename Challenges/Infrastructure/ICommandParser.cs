using Challenges.Commands;

namespace Challenges.Infrastructure
{
    internal interface ICommandParser
    {
        bool TryParse(string input, out ICommandHandler command, out string[] parameters);
    }
}
