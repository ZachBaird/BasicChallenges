using System;
using System.Linq;
using System.Text;

namespace BasicChallenges.CaesarCipher
{
    public sealed class CaesarCipher
    {
        private static int GetAsciiValue(string letter) => Encoding.ASCII.GetBytes(letter).First();

        /*
        private static string GetNewLetterOld(string letter, int encodeFactor)
        {
            int ascii = GetAsciiValue(letter);
            byte[] shiftedAscii = new byte[] { Convert.ToByte(ascii + encodeFactor) };

            int testAscii = GetAsciiValue(letter.ToUpper()) + encodeFactor;

            if (testAscii < 65 || testAscii > 90)
            {
                int difference = testAscii < 65 ? 65 - testAscii : testAscii - 90;

                // If our testAscii is less than 65, then we want to find the ascii backwards from 90 (Z).
                // If our testAscii wasn't, then we want to find the ascii forwards from 65 (A)
                int newAscii = (testAscii < 65) switch
                {
                    true => 91 - difference,
                    false => 64 + difference
                };

                return Encoding.ASCII.GetString(new byte[] { Convert.ToByte(newAscii) });
            }

            return Encoding.ASCII.GetString(shiftedAscii);
        } 
        */

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

        private static char MapNewChars(char character, int encodeFactor)
        {
            if (char.IsLetter(character))
            {
                string newLetter = GetNewLetter(character.ToString(), encodeFactor);
                return newLetter.ToCharArray().First();
            }

            return character;
        }

        public static string Encode(string stringToEncode, int encodeFactor)
        {
            char[] chars = stringToEncode.ToCharArray();

            char[] updatedChars = chars.Select(c => MapNewChars(c, encodeFactor)).ToArray();

            return string.Join(string.Empty, updatedChars);
        }
    }
}
