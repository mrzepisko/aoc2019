using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2019.Intcode;

namespace AdventOfCode2019
{
    public class Day02 : Day
    {
        
        public override string Name => "--- Day 2: 1202 Program Alarm ---";
        public override string Input => InputResources.Day02;
        private Processor processor;
        private InteropProgram program;
        public Day02()
        {
            this.processor = Processor.CreateBasic();
        }

        public override void ParseInput(string input)
        {
            program = new InteropProgram(input);
        }

        public override string PartOne()
        {
            int result = processor.Execute(program.Prepare(), 12, 02);
            return result.ToString();
        }

        public override string PartTwo()
        {
            const int desiredOutput = 19690720;

            int result = 0;
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    if (desiredOutput == processor.Execute(program.Prepare(), noun, verb))
                    {
                        result = noun * 100 + verb;
                    }
                }
            }
            return result.ToString();
        }
    }
}