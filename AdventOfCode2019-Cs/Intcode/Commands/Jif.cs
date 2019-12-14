namespace AdventOfCode2019.Intcode.Commands
{
    public class Jif : Command
    {
        private const int ParamId1 = 0, ParamId2 = 1;
        
        public Jif() : base(2) { }

        public override int OpCode => 6;
        protected override bool Process(Context ctx)
        {
            var value = ReadValue(ctx, ParamId1);
            if (value == 0)
            {
                var target = ReadValue(ctx, ParamId2);
                ctx.PC = target - Size; //haxx, I'll be mad some day
            }
            return true;
        }
    }
}