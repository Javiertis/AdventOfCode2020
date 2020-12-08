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
            _input = Input.SplitByNewline().Select(a => a.Split(" ")).ToArray();
        }

        protected override string SolvePartOne()
        {
            return Boot(_input)[1].ToString();
        }

        protected override string SolvePartTwo()
        {
            int accum = 0;
            for (int changes = _input.Length - 1; changes >= 0; changes--)
            {
                List<string[]> modIn = Input.SplitByNewline().Select(a => a.Split(" ")).ToList();
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
                if (output[0] == modIn.Count) return output[1].ToString();
            }
            return "0";
        }

        private int[] Boot(string[][] bootseq)
        {
            HashSet<int> visitedPos = new HashSet<int>();
            int pointer = 0, accum = 0;
            while (!visitedPos.Contains(pointer))
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

        private int[] Boot(List<string[]> bootseq)
        {
            HashSet<int> visitedPos = new HashSet<int>();
            int pointer = 0, accum = 0;
            while (!visitedPos.Contains(pointer) && pointer < bootseq.Count)
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