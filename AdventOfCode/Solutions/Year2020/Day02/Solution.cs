using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day02 : ASolution
    {
        private string[] _input;
        private int validPassCount, min, max, letterCount;
        private string letter, pass;

        public Day02() : base(02, 2020, "")
        {
            _input = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            validPassCount = 0;
            foreach (var item in _input)
            {
                string[] tmp = item.Split(new char[] { ':', '-', ' ' });
                min = int.Parse(tmp[0]);
                max = int.Parse(tmp[1]);
                letter = tmp[2];
                pass = tmp[4];
                letterCount = pass.Count(a => letter.Contains(a));
                if (letterCount >= min && letterCount <= max) validPassCount++;
            }
            return validPassCount.ToString();
        }

        protected override string SolvePartTwo()
        {
            validPassCount = 0;
            foreach (var item in _input)
            {
                string[] tmp = item.Split(new char[] { ':', '-', ' ' });
                min = int.Parse(tmp[0]);
                max = int.Parse(tmp[1]);
                letter = tmp[2];
                pass = tmp[4];
                if (pass[min - 1].ToString() == letter ^ pass[max - 1].ToString() == letter) validPassCount++;
            }
            return validPassCount.ToString();
        }
    }
}