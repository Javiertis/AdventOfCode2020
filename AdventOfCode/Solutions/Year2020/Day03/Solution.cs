using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day03 : ASolution
    {
        private string[] _input;

        public Day03() : base(03, 2020, "")
        {
            _input = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            return SlopeEncounter(3, 1).ToString();
        }

        protected override string SolvePartTwo()
        {
            return (SlopeEncounter(1, 1)
                * SlopeEncounter(3, 1)
                * SlopeEncounter(5, 1)
                * SlopeEncounter(7, 1)
                * SlopeEncounter(1, 2)).ToString();
        }

        private long SlopeEncounter(int r, int d)
        {
            long res = 0;
            for (int i = 0, j = 0; i < _input.Length; i += d, j += r)
            {
                if (j >= _input[i].Length) j = j - _input[i].Length;
                if (_input[i][j] == '#') res++;
            }
            return res;
        }
    }
}