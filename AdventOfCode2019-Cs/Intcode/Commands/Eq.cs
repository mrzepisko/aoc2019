namespace AdventOfCode2019.Intcode.Commands
{
    public class Eq : Command
    {
        private const int ParamId1 = 0, ParamId2 = 1, ParamId3 = 2;
        public Eq() : base(3) { }

        public override int OpCode => 8;
        protected override bool Process(Context ctx)
        {
            var val1 = ReadValue(ctx, ParamId1);
            var val2 = ReadValue(ctx, ParamId2);
            
            WriteValue(ctx, ParamId3, val1 == val2 ? 1 : 0);
            
            return true;
        }
    }
}