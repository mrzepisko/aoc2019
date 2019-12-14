using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class TerminateCommand : Command
    {
        public TerminateCommand() : base(0) { }

        public override int OpCode => 99;
        protected override bool Process(Context ctx) => false;
    }
}