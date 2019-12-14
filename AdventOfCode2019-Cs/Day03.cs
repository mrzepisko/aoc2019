using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Intcode.Wires;

namespace AdventOfCode2019
{
    public class Day03 : Day
    {
        private WirePanel panel;
        public override string Name => "--- Day 3: Crossed Wires ---";
        public override string Input => InputResources.Day03;
        public override void ParseInput(string input)
        {
            var wires = input.Split('\n');
            Wire wire1 = new Wire(wires[0]);
            Wire wire2 = new Wire(wires[1]);
            panel = new WirePanel(wire1, wire2);
        }

        public override string PartOne()
        {
            var result = panel.FindClosestIntersection();
            return result.Magnitude.ToString();
        }

        public override string PartTwo()
        {
            throw new System.NotImplementedException();
        }
    }
}