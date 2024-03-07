using Challenges.Services;
using Challenges.Algorithms;

namespace Challenges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationRunner runner = 
                new ApplicationRunner(
                    new PrimeNumberChecker(
                        new EratosthenesSieve()));
            
            runner.Run();
        }
    }
}
