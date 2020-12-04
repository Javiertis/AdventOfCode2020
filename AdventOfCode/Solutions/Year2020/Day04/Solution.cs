using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{
    internal class Day04 : ASolution
    {
        /*

    hgt (Height)
    ecl (Eye Color)
    pid (Passport ID)

         */
        private List<Dictionary<string, string>> _input;

        public Day04() : base(04, 2020, "")
        {
            _input = ParseInput();
        }

        protected override string SolvePartOne()
        {
            return _input
                .Count(d => AreThereAllKeys(d))
                .ToString();
        }

        protected override string SolvePartTwo()
        {
            return _input
                .Count(d =>
                {
                    return AreThereAllKeys(d)
                           && ByrRangeCorrect(d["byr"])
                           && IyrRangeCorrect(d["iyr"])
                           && EyrRangeCorrect(d["eyr"])
                           && PidCorrect(d["pid"])
                           && HeightCorrect(d["hgt"])
                           && EyeColorCorrect(d["ecl"])
                           && HairColorCorrect(d["hcl"]);
                })
                .ToString();
        }

        private bool AreThereAllKeys(Dictionary<string, string> d)
        {
            return d.ContainsKey("byr")
                        && d.ContainsKey("iyr")
                        && d.ContainsKey("eyr")
                        && d.ContainsKey("hgt")
                        && d.ContainsKey("hcl")
                        && d.ContainsKey("ecl")
                        && d.ContainsKey("pid");
        }

        private bool ByrRangeCorrect(string byr)
        {
            int byrInt = int.Parse(byr);
            return byrInt >= 1920 && byrInt <= 2002;
        }

        private bool IyrRangeCorrect(string iyr)
        {
            int iyrInt = int.Parse(iyr);
            return iyrInt >= 2010 && iyrInt <= 2020;
        }

        private bool EyrRangeCorrect(string eyr)
        {
            int eyrInt = int.Parse(eyr);
            return eyrInt >= 2020 && eyrInt <= 2030;
        }

        private bool HeightCorrect(string hgt)
        {
            int value = int.Parse(hgt.TrimEnd('c', 'm', 'i', 'n'));
            return (hgt.EndsWith("cm") && value >= 150 && value <= 193)
                   || (hgt.EndsWith("in") && value >= 59 && value <= 76);
        }

        private bool HairColorCorrect(string color)
        {
            return color.StartsWith("#")
                && color.Count(a =>
                {
                    return char.IsLetterOrDigit(a)
                        && "0123456789abcdef".Contains(a);
                }) == 6;
        }

        private bool EyeColorCorrect(string color)
        {
            return new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(color);
        }

        private bool PidCorrect(string pid)
        {
            return pid.Count(c => char.IsDigit(c)) == 9;
        }

        private List<Dictionary<string, string>> ParseInput()
        {
            var groups = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
            };

            int index = 0;

            foreach (string line in Input.Split("\n", StringSplitOptions.None))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    groups.Add(new Dictionary<string, string>());
                    ++index;
                    continue;
                }

                foreach (var word in line.Split(' '))
                {
                    var pair = word.Split(':');
                    groups[index][pair[0]] = pair[1];
                }
            }

            return groups;
        }
    }
}