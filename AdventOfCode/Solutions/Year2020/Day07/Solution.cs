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
            return CountBags2(colorBag, 1).ToString();
        }

        private HashSet<string> colors = new HashSet<string>();

        public void CountBags1(string bag)
        {
            if (colors.Add(bag))
                _input.Where(a => a.Value.Contains(bag))
                      .Select(a => a.Key)
                      .ToList()
                      .ForEach(a => CountBags1(a));
        }

        private Dictionary<string, string[][]> bagsVisited = new Dictionary<string, string[][]>();
        private string[][] bagsInside;

        public int CountBags2(string bag, int c)
        {
            if (bagsVisited.ContainsKey(bag))
            {
                bagsInside = bagsVisited[bag];
            }
            else
            {
                bagsInside = _input[bag].Trim('.')
                                        .Split(",", StringSplitOptions.TrimEntries)
                                        .Select(a => a.Split(' ', 2))
                                        .ToArray();
                bagsVisited.Add(bag, bagsInside);
            }

            if (bagsInside[0][0] == "no")
            {
                return c;
            }

            return (bag != colorBag ? c : 0) + c * bagsInside.Select(a => CountBags2(a[1], Convert.ToInt32(a[0]))).Sum();
        }
    }
}