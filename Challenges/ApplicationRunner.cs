using Challenges.Services;

namespace Challenges
{
    internal class ApplicationRunner
    {
        private readonly IPrimeNumberChecker _primeNumberChecker;

        public ApplicationRunner(IPrimeNumberChecker primeNumberChecker)
        {
            this._primeNumberChecker = primeNumberChecker;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Podaj liczbe:");
                var input = Console.ReadLine();
                if (!long.TryParse(input, out var number))
                {
                    Console.WriteLine("Niepoprawna liczba !!!");
                    continue;
                }

                if (_primeNumberChecker.IsPrime(number)) 
                    Console.WriteLine("Liczba jest pierwsza.");
                else 
                    Console.WriteLine("Liczba nie jest pierwsza.");
            }
        }
    }
}
