namespace Challenges
{
    public class HexCodeValidator
    {
        public bool IsValid(string hexcode)
            => hexcode.StartsWith("#") &&
               hexcode.Length == 7 &&
               hexcode.Skip(1).All(c => isDigit(c) || isHexLetter(c));

        private static bool isDigit(char c)
            => c >= '0' && c <= '9';

        private static bool isHexLetter(char c)
            => (c >= 'A' && c <= 'F');
    }
}
