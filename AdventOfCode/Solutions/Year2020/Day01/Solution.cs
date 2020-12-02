using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day01 : ASolution
    {
        private readonly List<int> _input;

        public Day01() : base(01, 2020, "")
        {
            _input = Input.SplitByNewline().AsEnumerable().Select(int.Parse).ToList();
        }

        protected override string SolvePartOne()
        {
            return NestedForeach();
        }

        private string NestedForeach()
        {
            var memo = new HashSet<int>();
            foreach (var input in _input)
            {
                if (input > 2020) continue;
                foreach (var n in memo)
                {
                    if (n + input == 2020)
                    {
                        return (n * input).ToString();
                    }
                }
                memo.Add(input);
            }
            return null;
        }

        private string NestedClassicFors()
        {
            for (int i = 0; i < _input.Count; i++)
            {
                for (int j = i + 1; j < _input.Count; j++)
                {
                    if (_input[i] + _input[j] == 2020) return $"{_input[i] * _input[j]}";
                }
            }
            return null;
        }

        protected override string SolvePartTwo()
        {
            for (int i = 0; i < _input.Count; i++)
            {
                for (int j = i + 1; j < _input.Count; j++)
                {
                    for (int k = j + 1; k < _input.Count; k++)
                    {
                        if (_input[i] + _input[j] + _input[k] == 2020) return $"{_input[i] * _input[j] * _input[k]}";
                    }
                }
            }
            return null;
        }
    }
}