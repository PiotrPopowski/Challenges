using System.Text;

namespace Challenges.Alghoritms
{
    public class Ceaser
    {
        private readonly uint _shift;
        private static char[] Alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        private static char[] PunctuationMarks = [' ', '.'];

        public Ceaser(uint shift)
        {
            if (shift > 27 || shift == 0) throw new ArgumentException("Ceaser shift must be in range 0-26.");
            _shift = shift;
        }

        public string Encode(string text)
        {
            text = text.ToUpper();
            if (!CanBeEncoded(text))
            {
                throw new Exception("Cannot encode text. Detected unsupported characters.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                var encodedC = PunctuationMarks.Contains(c) ? c : Alphabet[encode(c)];
                sb.Append(encodedC);
            }

            return sb.ToString();

            uint encode(char c) => (uint)((Array.IndexOf(Alphabet, c) + _shift) % Alphabet.Length);
        }

        public string Decode(string text)
        {
            text = text.ToUpper();
            if (!CanBeEncoded(text))
            {
                throw new Exception("Cannot decode text. Detected unsupported characters.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                var decodedC = PunctuationMarks.Contains(c) ? c : Alphabet[decode(c)];
                sb.Append(decodedC);
            }

            return sb.ToString();

            uint decode(char c) => (uint)((Array.IndexOf(Alphabet, c) - _shift + Alphabet.Length) % Alphabet.Length);
        }

        private static bool CanBeEncoded(string text) => text.Except(PunctuationMarks).All(Alphabet.Contains);
    }
}
