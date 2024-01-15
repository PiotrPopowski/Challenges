using Challenges;

namespace UnitTests
{
    public class HexCodeValidatorTest
    {
        [Theory]
        [InlineData("#123456", true)]
        [InlineData("#123", false)]
        public void hexcode_has_exactly_6_characters(string hexcode, bool isValid)
        {
            var sut = new HexCodeValidator();

            var isHexCodeValid = sut.IsValid(hexcode);

            Assert.True(isHexCodeValid == isValid);
        }

        [Theory]
        [InlineData("#AB29C0", true)]
        [InlineData("#000000", true)]
        [InlineData("#FFFFFF", true)]
        [InlineData("#GC1234", false)]
        [InlineData("#ABCD_F", false)]
        [InlineData("#ABCD#5", false)]
        public void hexcode_contains_only_letters_from_A_to_F_and_digits(string hexcode, bool isValid)
        {
            var sut = new HexCodeValidator();

            var isHexCodeValid = sut.IsValid(hexcode);

            Assert.True(isHexCodeValid == isValid);
        }

        [Theory]
        [InlineData("#123456", true)]
        [InlineData("0123456", false)]
        public void hexcode_starts_with_hash(string hexcode, bool isValid)
        {
            var sut = new HexCodeValidator();

            var isHexCodeValid = sut.IsValid(hexcode);

            Assert.True(isHexCodeValid == isValid);
        }
    }
}