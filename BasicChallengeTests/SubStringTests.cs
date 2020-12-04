using BasicChallenges.Substrings;
using System.Collections.Generic;
using Xunit;

namespace BasicChallengeTests
{
    public sealed class SubStringTests
    {
        [Fact]
        public void CorrectlyCountsHelloAndHell()
        {
            string[] dictionary = new string[] { "hell", "hello" };
            string stringToParse = "hello";

            List<SubstringRecord> expected = new List<SubstringRecord>
            {
                new SubstringRecord
                {
                    Substring = "hell",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "hello",
                    NumberOfOccurences = 1
                }
            };

            List<SubstringRecord> actual = Substrings.Substring(stringToParse, dictionary);

            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void CorrectlyCountsOdinExampleSubstrings()
        {
            string[] dictionary = new string[] { "below", "down", "go", "going", "horn", "how", "howdy", "it", "i",
                "low", "own", "part", "partner", "sit" };
            string stringToParse = "Howdy partner, sit down! How's it going?";

            List<SubstringRecord> expected = new List<SubstringRecord>
            {
                new SubstringRecord
                {
                    Substring = "down",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "go",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "going",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "how",
                    NumberOfOccurences = 2
                },
                new SubstringRecord
                {
                    Substring = "howdy",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "it",
                    NumberOfOccurences = 2
                },
                new SubstringRecord
                {
                    Substring = "i",
                    NumberOfOccurences = 3
                },
                new SubstringRecord
                {
                    Substring = "own",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "part",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "partner",
                    NumberOfOccurences = 1
                },
                new SubstringRecord
                {
                    Substring = "sit",
                    NumberOfOccurences = 1
                }
            };

            List<SubstringRecord> actual = Substrings.Substring(stringToParse, dictionary);

            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void GetDanmarkFromStringWitNumbers()
        {
            string[] dictionary = new string[] { "danmark" };
            string stringToParse = "Danmark123";

            List<SubstringRecord> expected = new List<SubstringRecord>
            {
                new SubstringRecord
                {
                    Substring = "danmark",
                    NumberOfOccurences = 1
                }
            };

            List<SubstringRecord> actual = Substrings.Substring(stringToParse, dictionary);

            Assert.Equal(expected, actual);
            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void CountJimmy7Times()
        {
            string[] dictionary = new string[] { "jim" };
            string stringToParse = "Jim jim Jimmy Jimster Jimbob, JimJim";

            List<SubstringRecord> actual = Substrings.Substring(stringToParse, dictionary);

            Assert.Equal(7, actual[0].NumberOfOccurences);
        }
    }
}
