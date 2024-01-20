using Challenges.Commands;
using Challenges.Infrastructure;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceLocator = new ServiceLocator();
            Setup(serviceLocator);

            var commandParser = serviceLocator.Create<ICommandParser>();

            Start(commandParser);
        }

        private static void Start(ICommandParser commandParser)
        {
            string input = "";
            ICommandHandler commandHandler;
            string[] cmdArgs;

            while (input != "exit")
            {
                input = Console.ReadLine();

                var response = commandParser.TryParse(input, out commandHandler, out cmdArgs)
                    ? commandHandler.Execute(cmdArgs)
                    : "Could not parse the command";

                Console.WriteLine(response);
            }
        }

        static void Setup(ServiceLocator serviceLocator)
        {
            serviceLocator.Register<ICommandDispatcher>(x => new CommandDispatcher(x, GetCommandMapping()));
            serviceLocator.Register<ICommandParser>(x => new CommandParser(x.Create<ICommandDispatcher>()));
            serviceLocator.Register<SumCommandHandler>(x => new SumCommandHandler());
            serviceLocator.Register<HelloCommandHandler>(x => new HelloCommandHandler());
        }

        private static Dictionary<string, Type> GetCommandMapping()
        {
            return new Dictionary<string, Type>()
            {
                { "sum", typeof(SumCommandHandler) },
                { "hello", typeof(HelloCommandHandler) }
            };
        }
    }
}
