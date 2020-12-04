using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasicChallenges.Substrings
{
    public sealed class Substrings
    {
        private static SubstringRecord CreateRecord(string stringToParse, string substring)
        {
            SubstringRecord record = new SubstringRecord
            {
                Substring = substring,
                NumberOfOccurences = 0
            };

            string[] words = stringToParse.Split(',', '.', ' ', '?', '!', ';', ':')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .Select(w => w.ToLower()).ToArray();

            foreach (string word in words)
                if (word == record.Substring || word.Contains(record.Substring))
                    record.NumberOfOccurences += Regex.Matches(word, record.Substring).Count;

            return record;
        }

        public static List<SubstringRecord> Substring(string stringToParse, string[] dictionary)
        {
            List<SubstringRecord> results = new List<SubstringRecord>();

            string lowerCasedString = stringToParse.ToLower();
            foreach (string word in dictionary)
            {
                if (lowerCasedString.Contains(word))
                {
                    results.Add(CreateRecord(stringToParse, word));
                }
            }

            return results;
        }
    }
}
