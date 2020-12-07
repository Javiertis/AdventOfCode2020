using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day07 : ASolution
    {
        private Dictionary<string, string> _input;
        private string colorBag = "shiny gold bag";

        public Day07() : base(07, 2020, "")
        {
            string test = "shiny gold bags contain 2 dark red bags.\n" +
                "dark red bags contain 2 dark orange bags.\n" +
                "dark orange bags contain 2 dark yellow bags.\n" +
                "dark yellow bags contain 2 dark green bags.\n" +
                "dark green bags contain 2 dark blue bags.\n" +
                "dark blue bags contain 2 dark violet bags.\n" +
                "dark violet bags contain no other bags.";

            string test2 = "shiny gold bags contain 3 dark red bags.\n" +
                "dark red bags contain 2 dark orange bags.\n" +
                "dark orange bags contain 5 dark yellow bags.\n" +
                "dark yellow bags contain 1 dark green bags.\n" +
                "dark green bags contain 4 dark blue bags.\n" +
                "dark blue bags contain 7 dark violet bags.\n" +
                "dark violet bags contain no other bags.";
            _input = Input.SplitByNewline()
                          .ToDictionary(a => a.Split("contain", StringSplitOptions.TrimEntries)[0].Replace("bags", "bag"),
                                        b => b.Split("contain", StringSplitOptions.TrimEntries)[1].Replace("bags", "bag"));
        }

        protected override string SolvePartOne()
        {
            CountBags1(colorBag);
            return colors.Count(a => a != colorBag).ToString();
        }

        protected override string SolvePartTwo()
        {
            return (CountBags2(colorBag, 1)).ToString();
        }

        private HashSet<string> colors = new HashSet<string>();

        public void CountBags1(string bag)
        {
            if (colors.Add(bag))
                _input.Where(a => a.Value.Contains(bag)).Select(a => a.Key).ToList().ForEach(a => CountBags1(a));
        }

        public int CountBags2(string bag, int c)
        {
            var bagsInside = _input[bag].Trim('.')
                .Split(",", StringSplitOptions.TrimEntries)
                .Select(a => a.Split(' ', 2)).ToArray();
            if (bagsInside[0][0] == "no")
            {
                return c;
            }

            return (bag != colorBag ? c : 0) + c * bagsInside.Select(a => CountBags2(a[1], Convert.ToInt32(a[0]))).Sum();
        }
    }
}