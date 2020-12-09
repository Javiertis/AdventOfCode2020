using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day09 : ASolution
    {
        private int[] _input;

        public Day09() : base(09, 2020, "")
        {
            _input = Input.ToIntArray("\n");
        }

        protected override string SolvePartOne()
        {
            return GetError(_input, 25).ToString();
        }

        protected override string SolvePartTwo()
        {
            int errorNumber = GetError(_input, 25);
            return GetEncryptionWeakness(errorNumber, _input).ToString();
        }

        private int GetError(int[] arr, int preamble)
        {
            for (int i = preamble; i < arr.Length; i++)
            {
                int[] numbersBefore = arr[(i - preamble)..i];
                int numbersCorrect = 0;
                foreach (var number in numbersBefore)
                {
                    if (numbersBefore.Contains(arr[i] - number)) numbersCorrect++;
                }
                if (numbersCorrect == 0) return arr[i];
            }
            return -1;
        }

        private int GetEncryptionWeakness(int error, int[] arr)
        {
            List<int> contigousList = new List<int>();
            HashSet<int> biggerThanList = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (biggerThanList.Contains(arr[i])) continue;
                contigousList.Clear();
                int accum = arr[i];
                contigousList.Add(arr[i]);
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > error)
                    {
                        biggerThanList.Add(arr[j]);
                        break;
                    }
                    accum += arr[j];
                    contigousList.Add(arr[j]);
                    if (accum == error) return contigousList.Where(a => a == contigousList.Max()
                                                                           || a == contigousList.Min())
                                                                  .Sum();
                }
            }
            return -1;
        }
    }
}