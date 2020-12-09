using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day08 : ASolution
    {
        private string[][] _input;

        public Day08() : base(08, 2020, "")
        {
            _input = Input.SplitByNewline()
                          .Select(a => a.Split(" "))
                          .ToArray();
        }

        protected override string SolvePartOne()
        {
            return Boot(_input)[1].ToString();
        }

        protected override string SolvePartTwo()
        {
            for (int changes = 0; changes < _input.Length; changes++)
            {
                string[][] modIn = Input.SplitByNewline()
                                        .Select(a => a.Split(" "))
                                        .ToArray();
                if (modIn[changes][0] == "jmp")
                {
                    modIn[changes][0] = "nop";
                }
                else if (modIn[changes][0] == "nop")
                {
                    modIn[changes][0] = "jmp";
                }
                else
                {
                    continue;
                }
                var output = Boot(modIn);
                if (output[0] == modIn.Length)
                {
                    return output[1].ToString();
                }
            }
            return "";
        }

        private int[] Boot(string[][] bootseq)
        {
            HashSet<int> visitedPos = new HashSet<int>();
            int pointer = 0, accum = 0;
            while (!visitedPos.Contains(pointer) && pointer < bootseq.Length)
            {
                visitedPos.Add(pointer);
                if (bootseq[pointer][0] == "jmp")
                {
                    pointer += Convert.ToInt32(bootseq[pointer][1]);
                    continue;
                }
                if (bootseq[pointer][0] == "acc") accum += Convert.ToInt32(bootseq[pointer][1]);
                pointer++;
            }
            return new[] { pointer, accum };
        }
    }
}