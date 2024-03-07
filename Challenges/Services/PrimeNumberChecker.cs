using Challenges.Algorithms;

namespace Challenges.Services
{
    internal class PrimeNumberChecker : IPrimeNumberChecker
    {
        private IPrimeAlgorithm _primeNumberChecker;

        public PrimeNumberChecker(IPrimeAlgorithm primeNumberChecker)
        {
            _primeNumberChecker = primeNumberChecker;
        }

        public bool IsPrime(long number) 
            => _primeNumberChecker.IsPrime(number);
    }
}
