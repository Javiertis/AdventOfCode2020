using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day06 : ASolution
    {
        private List<string> _input;

        public Day06() : base(06, 2020, "")
        {
            Input.ParseInputStringToList(out _input);
        }

        protected override string SolvePartOne()
        {
            return _input
                   .Select(
                            a => a.Where(a => a != '\n')
                                  .Distinct()
                                  .Count()
                          )
                   .Sum()
                   .ToString();
        }

        protected override string SolvePartTwo()
        {
            int total = 0;
            int[] counter;
            string[] groupLines;
            foreach (var group in _input)
            {
                counter = new int[26];
                groupLines = group.Split('\n');
                groupLines.JoinAsStrings()
                          .ToList()
                          .ForEach(a => counter[a - 'a']++);
                total += counter.Count(a => a == groupLines.Length);
            }
            return total.ToString();
        }
    }
}