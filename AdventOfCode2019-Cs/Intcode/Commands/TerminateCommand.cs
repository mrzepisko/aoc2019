namespace AdventOfCode2019.Intcode.Commands
{
    public class TerminateCommand : Command
    {
        public TerminateCommand() : base(99, 0) { }

        protected override bool Process(int addr, ref int[] memo) => false;
    }
}