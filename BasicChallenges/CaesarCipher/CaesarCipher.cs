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
            // Determine if we breach the bounds of the alphabet in ASCII.
            int ascii = GetAsciiValue(letter.ToUpper()) + encodeFactor;
            if (ascii < 65 || ascii > 90)
            {
                int difference = ascii < 65 ? 65 - ascii : ascii - 90;

                // If our testAscii is less than 65, then we want to find the ascii backwards from 90 (Z).
                // If our testAscii wasn't, then we want to find the ascii forwards from 65 (A)
                int newAscii = (ascii < 65) switch
                {
                    true => 91 - difference,
                    false => 64 + difference
                };

                return Encoding.ASCII.GetString(new byte[] { Convert.ToByte(newAscii) });
            }

            // Since we are within the bounds of the alphabet, proceed as normal.
            byte[] shiftedAscii = new byte[] { Convert.ToByte(ascii + encodeFactor) };
            return Encoding.ASCII.GetString(shiftedAscii);
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
