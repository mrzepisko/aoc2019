using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public class SetValueCmd : Command
    {
        private const int ParamTargetId = 1;
        public SetValueCmd(int opCode, int paramCount) : base("03") { }

        protected override bool Process(Context ctx)
        {
            int value = ctx.ReadInput();
            WriteValue(ctx, ParamTargetId, value);
            return true;
        }
    }
}