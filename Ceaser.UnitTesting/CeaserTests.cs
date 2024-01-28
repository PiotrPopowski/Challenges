namespace Ceaser.UnitTesting
{
    public class CeaserTests
    {
        [Theory]
        [InlineData("A", "E", 4)]
        [InlineData("year", "AGCT", 2)]
        [InlineData("Today is a great day.", "NIXUS CM U ALYUN XUS.", 20)]
        public void ceaser_alghoritm_encodes_given_text(string text, string encodedText, uint shift)
        {
            var ceaser = new Challenges.Alghoritms.Ceaser(shift);

            var encoded = ceaser.Encode(text);
            
            Assert.Equal(encodedText, encoded);
        }

        [Theory]
        [InlineData("E", "A", 4)]
        [InlineData("AGCT", "YEAR", 2)]
        [InlineData("NIXUS CM U ALYUN XUS.", "TODAY IS A GREAT DAY.", 20)]
        public void ceaser_alghoritms_decodes_given_text(string encodedText, string decodedText, uint shift)
        {
            var ceaser = new Challenges.Alghoritms.Ceaser(shift);

            var text = ceaser.Decode(encodedText);

            Assert.Equal(decodedText, text);
        }
    }
}
