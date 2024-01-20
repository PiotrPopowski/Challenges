using Challenges.Commands;

namespace Challenges.Infrastructure
{
    internal interface ICommandDispatcher
    {
        ICommandHandler Dispatch(string command, string[] arg);
    }
}
