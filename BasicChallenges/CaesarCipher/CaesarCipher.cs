using System;
using System.Linq;
using System.Text;

namespace BasicChallenges.CaesarCipher
{
    /// <summary>
    /// Contains static functionality for encoding string data according to the Caesar Cipher.
    /// </summary>
    public sealed class CaesarCipher
    {
        /// <summary>
        /// Gets the ASCII value of a character and returns it as an int.
        /// </summary>
        /// <param name="letter">The letter to get the ASCII value of.</param>
        /// <returns>The ASCII value.</returns>
        private static int GetAsciiValue(string letter) => Encoding.ASCII.GetBytes(letter).First();

        /// <summary>
        /// Returns a new letter after applying the shift.
        /// </summary>
        /// <param name="letter">The original letter.</param>
        /// <param name="encodeFactor">How far to shift the letter in the alphabet.</param>
        /// <returns>The new letter.</returns>
        private static string GetNewLetter(string letter, int encodeFactor)
        {
            int upperCaseAscii = GetAsciiValue(letter.ToUpper()) + encodeFactor;
            var newAsciiValue = upperCaseAscii switch
            {
                < 65 => 91 - (65 - upperCaseAscii),
                > 90 => 64 + (upperCaseAscii - 90),
                _ => GetAsciiValue(letter) + encodeFactor
            };

            return Encoding.ASCII.GetString(new byte[] { Convert.ToByte(newAsciiValue) });
        }

        /// <summary>
        /// Maps an original character to a new character unless it isn't alphabetical.
        /// </summary>
        /// <param name="character">The original character.</param>
        /// <param name="encodeFactor">How far to shift the character in the alphabet.</param>
        /// <returns></returns>
        private static char MapChar(char character, int encodeFactor)
        {
            if (!char.IsLetter(character)) return character;

            string newLetter = GetNewLetter(character.ToString(), encodeFactor);
            return newLetter.ToCharArray().First();
        }

        /// <summary>
        /// Main encoding method for the Caesar Cipher.
        /// </summary>
        /// <param name="stringToEncode">A message to encode.</param>
        /// <param name="encodeFactor">The factor by which to encode the <paramref name="stringToEncode"/>.</param>
        /// <returns>The encoded string per the Caesar Cipher.</returns>
        public static string Encode(string stringToEncode, int encodeFactor)
        {
            char[] chars = stringToEncode.ToCharArray();

            char[] updatedChars = chars.Select(c => MapChar(c, encodeFactor)).ToArray();

            return string.Join(string.Empty, updatedChars);
        }
    }
}
