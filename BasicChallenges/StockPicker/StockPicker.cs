using Challenges.Library;
using System.Linq;

namespace BasicChallenges.StockPicker
{
    /// <summary>
    /// Static functionaity to determine when to buy and sell a stock based on share price.
    /// </summary>
    public sealed class StockPicker
    {
        /// <summary>
        /// Driving method for the StockPicker.
        /// </summary>
        /// <param name="days">An int array of share prices per day.</param>
        /// <returns>A custom Result type either representing Success or Failure. Success will contain
        ///  the resulting days to buy and sell.</returns>
        public static Result<(int, int), string> Pick(int[] days)
        {
            var (lowest, highest) = days.SelectMany((_, l) => days.Select((_, h) => (low: l, high: l + h)))
                            .Where(combo => combo.high < days.Length)
                            .Aggregate((current, next) =>
                                days[current.high] - days[current.low] > days[next.high] - days[next.low] ? current : next);

            if (lowest == highest)
                return new Result<(int, int), string>.Failure("No lower day before high day present.");
            else
                return new Result<(int, int), string>.Success((lowest, highest));
        }
    }
}
