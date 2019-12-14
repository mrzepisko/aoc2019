using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class SetValueCmd : Command
    {
        private const int ParamTargetId = 0;
        public SetValueCmd() : base(1) { }

        public override int OpCode => 3;

        protected override bool Process(Context ctx)
        {
            long value = ctx.Input.Read();
            WriteValue(ctx, ParamTargetId, value);
            return true;
        }
    }
}