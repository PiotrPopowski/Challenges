namespace Challenges.Algorithms
{
    internal class EratosthenesSieve : IPrimeAlgorithm
    {
        public bool IsPrime(long number)
        {
            if (number < 0) number *= -1;

            for(int i = 2; i <= (number + 1) / 2; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
