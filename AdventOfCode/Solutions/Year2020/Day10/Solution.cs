using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day10 : ASolution
    {
        private List<int> _input;

        public Day10() : base(10, 2020, "")
        {
            string test = "16\n10\n15\n5\n1\n11\n7\n19\n6\n12\n4";
            string test2 = "28\n33\n18\n42\n31\n14\n46\n20\n48\n47\n24\n23\n49\n45\n19\n38\n39\n11\n1\n32\n25\n35\n8\n17\n7\n9\n4\n2\n34\n10\n3";
            _input = Input.ToIntArray("\n").ToList();
            _input.Add(_input.Max() + 3);
            _input.Add(0);
            _input = _input.OrderBy(a => a).ToList();
        }

        protected override string SolvePartOne()
        {
            int diff1 = 0, diff3 = 0;
            int last = _input.Min();
            foreach (var num in _input)
            {
                if (num - last == 3) diff3++;
                if (num - last == 1) diff1++;
                last = num;
            }
            return (diff1 * diff3).ToString();
        }

        protected override string SolvePartTwo()
        {
            return Paths(0).ToString();
        }

        private Dictionary<int, long> comb = new Dictionary<int, long>();

        private long Paths(int i)
        {
            if (i == _input.Count - 1) return 1;
            if (comb.ContainsKey(i)) return comb[i];
            long res = 0;
            for (int j = i + 1; j < _input.Count; j++)
            {
                if (_input[j] - _input[i] <= 3) res += Paths(j);
            }
            comb.Add(i, res);
            return res;
        }
    }
}