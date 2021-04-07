using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicChallenges.Substrings
{
    /// <summary>
    /// Contains static functionality for recording the occurence
    ///  of every word in the provided dictionary.
    /// </summary>
    public sealed class Substrings
    {
        /// <summary>
        /// Creates a Substring record for a word and the number of
        ///  times that word appears in a string.
        /// </summary>
        /// <param name="stringToParse">The string to parse through.</param>
        /// <param name="substring">The substring to tally in the record.</param>
        /// <returns>The resulting record.</returns>
        private static SubstringRecord CreateRecord(string stringToParse, string substring)
        {
            SubstringRecord record = new()
            {
                Substring = substring,
                NumberOfOccurences = 0
            };

            string[] words = stringToParse.Split(',', '.', ' ', '?', '!', ';', ':')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.ToLower()).ToArray();

            foreach (string word in words)
                record.NumberOfOccurences += Regex.Matches(word, record.Substring).Count;

            return record;
        }

        /// <summary>
        /// The driving method for the Substring program.
        /// </summary>
        /// <param name="stringToParse">The string to count words in.</param>
        /// <param name="dictionary">The dictionary of words to tally up.</param>
        /// <returns>A list of records for each dictionary word that had an
        ///  occurence in <paramref name="stringToParse"/>.</returns>
        public static List<SubstringRecord> Substring(string stringToParse, string[] dictionary)
        {           
            string lowerCasedString = stringToParse.ToLower();

            List<SubstringRecord> results = dictionary
                .Where(w => lowerCasedString.Contains(w))
                .Select(w => CreateRecord(stringToParse, w))
                .ToList();

            return results;
        }
    }
}
