using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using AdventOfCode2019.Intcode;
using AdventOfCode2019.Intcode.Commands;
using AdventOfCode2019.Intcode.Wires;

namespace AdventOfCode2019
{
    public class Day05 : Day
    {
        public override string Name => "--- Day 5: Sunny with a Chance of Asteroids ---";
        public override string Input => InputResources.Day05;

        private Processor processor;
        private InteropProgram program;


        public Day05()
        {
            processor = Processor.CreateBasic();
        }

        public override void ParseInput(string input)
        {
            program = new InteropProgram(input);
        }

        public override string PartOne()
        {
            Context ctx = program.Prepare();
            ctx.Input.Write(1);
            long result = processor.Execute(ctx);
            return result.ToString();
        }

        public override string PartTwo()
        {
            Context ctx = program.Prepare();
            ctx.Input.Write(5);
            long result = processor.Execute(ctx);
            return result.ToString();
        }
    }
}