namespace Challenges.Commands
{
    internal interface ICommandHandler
    {
        string Execute(string[] args);
    }
}
