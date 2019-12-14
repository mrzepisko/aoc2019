using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class AdditionCmd : Command
    {
        private const int ParamIn1 = 0, ParamIn2 = 1, ParamOut = 2;

        public override int OpCode => 1;

        public AdditionCmd() : base(3)
        {
        }

        protected override bool Process(Context ctx)
        {
            int val1 = ReadValue(ctx, ParamIn1),
                val2 = ReadValue(ctx, ParamIn2);

            WriteValue(ctx, ParamOut, val1 + val2);
            return true;
        }
    }
}