using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2019
{
    public class Day01 : Day
    {
        private int[] values;
        private int result1;
        private int result2;
        public override string Name => "--- Day 1: The Tyranny of the Rocket Equation ---";
        public override string Input => InputResources.Day01;

        public override void ParseInput(string input)
        {
            values = input.Split('\n')
                .Select(int.Parse)
                .ToArray();
        }

        public override string PartOne()
        {
            result1 = values.Select(CalculateRequiredFuel)
                .Sum();
            return result1.ToString();
        }

        public override string PartTwo()
        {
            result2 = values
                .Select(CalculateTotalFuel)
                .Sum();
            return result2.ToString();
        }

        private int CalculateRequiredFuel(int mass)
        {
            return mass / 3 - 2;
        }

        private int CalculateTotalFuel(int mass)
        {
            var fuel = CalculateRequiredFuel(mass);
            if (fuel > 0)
            {
                return fuel + CalculateTotalFuel(fuel);
            }
            else
            {
                return fuel;
            }
        }
    }
}