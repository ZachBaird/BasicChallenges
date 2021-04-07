using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicChallenges.StockPicker;
using Challenges.Library;
using Xunit;

namespace BasicChallengeTests
{
    public sealed class StockPickerTests
    {
        [Fact]
        public void CorrectlyPicksSecondAndFifthDays()
        {
            int[] days = new int[] { 17, 3, 6, 9, 15, 8, 6, 1, 10 };

            var s = StockPicker.Pick(days) as Result<(int, int), string>.Success;

            Assert.Equal((1, 4), s?.Value);
        }

        [Fact]
        public void CorrectlyPicksLastTwoDays()
        {
            int[] days = new int[] { 11, 9, 10, 3, 10 };

            var s = StockPicker.Pick(days) as Result<(int, int), string>.Success;

            Assert.Equal((3, 4), s?.Value);            
        }

        [Fact]
        public void CorrectlyPicksFirstTwoDays()
        {
            int[] days = new int[] { 0, 20, 10, 11, 9 };

            var s = StockPicker.Pick(days) as Result<(int, int), string>.Success;

            Assert.Equal((0, 1), s.Value);
        }

        [Fact]
        public void FailsWhenNoLowerPricePresent()
        {
            int[] days = new int[] { 20, 19, 15, 10 };

            var results = StockPicker.Pick(days) as Result<(int, int), string>.Failure;

            Assert.Equal("No lower day before high day present.", results?.Message);            
        }
    }
}
