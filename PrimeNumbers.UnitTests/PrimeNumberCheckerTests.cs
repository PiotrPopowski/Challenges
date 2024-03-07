using Challenges.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.UnitTests
{
    public class PrimeNumberCheckerTests
    {
        IPrimeNumberChecker sut;

        public PrimeNumberCheckerTests()
        {
            sut = new PrimeNumberChecker();
        }


        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(17)]
        [Theory]
        public void given_prime_number_returns_true(long number)
        {
            var result = sut.IsPrime(number);
        }
    }
}
