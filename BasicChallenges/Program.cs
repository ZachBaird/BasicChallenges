using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTuples = new List<(string, int)>
            {
                ("hello", 1),
                ("hi", 20),
                ("what's up", 10)
            };

            var maxItem = myTuples.Aggregate((best, next) => best.Item2 > next.Item2 ? best : next);
            Console.WriteLine("Finished.");

            var numbers = new int[] { 1, 2, 3 };
            var words = new string[] { "one", "two", "three" };

            var result = numbers.Zip(words, (first, second) => $"{first} {second}");
        }
    }
}
