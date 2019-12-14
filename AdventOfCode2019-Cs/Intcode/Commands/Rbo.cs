namespace AdventOfCode2019.Intcode.Commands
{
    public class Rbo : Command
    {
        private const int ParamId = 0;
        public Rbo() : base(1) { }

        public override int OpCode => 9;
        protected override bool Process(Context ctx)
        {
            var value = ctx.ReadParam(ParamId);
            ctx.RB += value;
            return true;
        }
    }
}