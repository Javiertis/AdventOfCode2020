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
            _input = ParseInput();
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

        private List<string> ParseInput()
        {
            List<string> groups = new List<string>();

            int index = 0;

            foreach (string line in Input.Split("\n", StringSplitOptions.None))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    ++index;
                    continue;
                }
                else if (groups.Count <= index)
                {
                    groups.Add(line);
                }
                else
                {
                    groups[index] += line + '\n';
                }
            }

            return groups;
        }
    }
}