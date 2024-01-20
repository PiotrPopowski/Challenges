using Challenges.Commands;

namespace Challenges.Infrastructure
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceLocator serviceLocator;
        private readonly Dictionary<string, Type> commandToHandlerDictionary = new Dictionary<string, Type>();

        public CommandDispatcher(IServiceLocator serviceLocator, Dictionary<string, Type> commandToHandlerMapping)
        {
            this.serviceLocator = serviceLocator;
            this.commandToHandlerDictionary = commandToHandlerMapping;
        }

        public ICommandHandler Dispatch(string command, string[] arg)
        {
            var handlerType = commandToHandlerDictionary[command];
            var handler = serviceLocator.Create<ICommandHandler>(handlerType);

            return handler;
        }
    }
}
