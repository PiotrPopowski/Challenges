using Challenges.Algorithms;

namespace PrimeNumbers.UnitTests
{
    public class EratosthenesSieveTests
    {
        EratosthenesSieve sut;

        public EratosthenesSieveTests()
        {
            sut = new Challenges.Algorithms.EratosthenesSieve();
        }


        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(17)]
        [Theory]
        public void given_prime_number_returns_true(long number)
        {
            var result = sut.IsPrime(number);

            Assert.True(result);
        }

        [InlineData(4)]
        [InlineData(12)]
        [InlineData(25)]
        [InlineData(100)]
        [Theory]
        public void given_not_a_prime_number_return_false(long number)
        {
            var result = sut.IsPrime(number);

            Assert.False(result);
        }
    }
}
