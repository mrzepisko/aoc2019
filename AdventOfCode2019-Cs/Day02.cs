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
            using (var execution = processor.Run(program))
            {
                execution.MoveNext();
                var memory = execution.Current;
                memory[1] = 12;
                memory[2] = 02;
                int[] lastMemo = memory;
                while (execution.MoveNext())
                {
                    lastMemo = execution.Current;
                }

                return lastMemo[0].ToString();
            }
            
        }

        public override string PartTwo()
        {
            return "";
        }
    }
}