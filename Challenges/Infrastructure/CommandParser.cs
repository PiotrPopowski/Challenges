using Challenges.Commands;

namespace Challenges.Infrastructure
{
    internal sealed class CommandParser : ICommandParser
    {
        private readonly ICommandDispatcher commandDispatcher;

        public CommandParser(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public bool TryParse(string input, out ICommandHandler command, out string[] parameters)
        {
            command = null;
            parameters = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            (string[] args, string inputCmd) = dispatchInput(input);

            try 
            {
                command = commandDispatcher.Dispatch(inputCmd, args);
                parameters = args;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static (string[] args, string inputCmd) dispatchInput(string input)
        {
            var inputSplit = input.Split(' ');
            if(inputSplit.Length == 1 )
            {
                return (Array.Empty<string>(), inputSplit[0]);
            }

            var cmd = inputSplit.First();
            var args = inputSplit.Skip(1);

            return (args.ToArray(), cmd);
        }
    }
}
