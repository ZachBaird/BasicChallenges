namespace BasicChallenges.Substrings
{
    /// <summary>
    /// A record for a word (as a substring) and how often it occurred in a string.
    /// </summary>
    public record SubstringRecord
    {
        public string Substring { get; set; }
        public int NumberOfOccurences { get; set; }
    }
}
