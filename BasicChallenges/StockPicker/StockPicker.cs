using Challenges.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.
    Threading.Tasks;

namespace BasicChallenges.StockPicker
{
    public sealed class StockPicker
    {
        public static Result<(int, int), string> Pick(int[] days)
        {
            //Result<(int, int), string> results;

            var (lowest, highest) = days.SelectMany((_, l) => days.Select((_, h) => (low: l, high: l + h)))
                 .Where(combo => combo.high < days.Length)
                 .Aggregate((current, next) =>
                     days[current.high] - days[current.low] > days[next.high] - days[next.low] ? current : next);

            if (lowest == highest)
                return new Result<(int, int), string>.Failure("No lower day before high day present.");
            else
                return new Result<(int, int), string>.Success((lowest, highest));

           // return results;
        }
    }
}
