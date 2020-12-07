using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day05 : ASolution
    {
        private string[] _input;

        public Day05() : base(05, 2020, "")
        {
            _input = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            long maxID = long.MinValue;
            foreach (string boardPass in _input)
            {
                int row = BinarySpaceSearch(boardPass.Substring(0, 7), Enumerable.Range(0, 128));
                int column = BinarySpaceSearch(boardPass[7..], Enumerable.Range(0, 8));
                maxID = Math.Max(maxID, GetSeatID(row, column));
            }
            return maxID.ToString();
        }

        protected override string SolvePartTwo()
        {
            SortedSet<long> IDs = new SortedSet<long>();
            foreach (string boardPass in _input)
            {
                int row = BinarySpaceSearch(boardPass.Substring(0, 7), Enumerable.Range(0, 128));
                int column = BinarySpaceSearch(boardPass[7..], Enumerable.Range(0, 8));
                IDs.Add(GetSeatID(row, column));
            }
            IEnumerable<long> vs = IDs.AsEnumerable<long>();
            for (int i = 1; i < vs.Count() - 1; i += 2)
            {
                if (vs.ElementAt(i) - vs.ElementAt(i - 1) == 2) return (vs.ElementAt(i) - 1).ToString();
                if (vs.ElementAt(i + 1) - vs.ElementAt(i) == 2) return (vs.ElementAt(i) + 1).ToString();
            }

            return "";
        }

        private int BinarySpaceSearch(string searchStr, IEnumerable<int> range)
        {
            if (searchStr == "") return range.Single();
            if ("FL".Contains(searchStr[0]))
            {
                return BinarySpaceSearch(searchStr.Remove(0, 1), range.Split(range.Count() / 2).First());
            }
            else
            {
                return BinarySpaceSearch(searchStr.Remove(0, 1), range.Split(range.Count() / 2).Last());
            }
        }

        private long GetSeatID(int row, int column) => row * 8 + column;
    }
}