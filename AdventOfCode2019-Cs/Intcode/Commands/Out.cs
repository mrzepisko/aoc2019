using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class OutputValueCmd : Command
    {
        private const int ParamTargetId = 0;
        public OutputValueCmd() : base(1) { }

        public override int OpCode => 4;

        protected override bool Process(Context ctx)
        {
            long value = ReadValue(ctx, ParamTargetId);
            ctx.Output.Write(value);
            return true;
        }
    }
}