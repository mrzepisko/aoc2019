using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Intcode.Wires;

namespace AdventOfCode2019
{
    public class Day04 : Day
    {
        private int min, max;
        public override string Name => "--- Day 4: Secure Container ---";
        public override string Input => "234208-765869";
        public override void ParseInput(string input)
        {
            string pattern = @"(?<min>\d+)-(?<max>\d+)";
            var m = Regex.Match(input, pattern);
            min = int.Parse(m.Groups["min"].Value);
            max = int.Parse(m.Groups["max"].Value);
        }

        public override string PartOne()
        {
            return FindPassword(min, max);
        }

        public override string PartTwo()
        {
            return FindPassword(min, max, true);
        }

        string FindPassword(int min, int max, bool extra = false)
        {
            List<string> validPasswords = new List<string>();
            for (int passValue = min; passValue <= max; passValue++)
            {
                string password = passValue.ToString();
                if (IsValidPassword(password))
                {
                    if (extra && !HasOnlyOneDouble(password)) continue;
                    validPasswords.Add(password);
                }
            }

            return validPasswords.Count.ToString();
        }

        private bool HasOnlyOneDouble(string password)
        {
            const string pattern = @"((\d)\2+)";
            var matchList = Regex.Matches(password, pattern);
            for (int i = 0; i < matchList.Count; i++)
            {
                var m = matchList[i];
                if (m.Groups[1].Length == 2 && m.Groups[2].Length == 1) return true;
            }
            return false;
        }

        private bool IsValidPassword(string password)
        {
            return IsSixDigits(password) 
                   && HasDouble(password) 
                   && IsOrdered(password);
        }

        private bool IsSixDigits(string str)
        {
            return str.Length == 6;
        }
        private static bool HasDouble(string str)
        {
            const string pattern = @"(\d)\1";
            return Regex.IsMatch(str, pattern);
        }

        private static bool IsOrdered(string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                char curr = str[i],
                    prev = str[i - 1];
                if (curr < prev) return false;
            }

            return true;
        }
    }
}