namespace AdventOfCode2019.Intcode.Commands
{
    public class MultiplicationCmd : Command
    {
        public MultiplicationCmd() : base(2, 3) { }
        protected override bool Process(int addr, ref int[] memo)
        {
            int addrIn1 = AddrIn1(addr, memo),
                addrIn2 = AddrIn2(addr, memo),
                addrOut = AddrOut(addr, memo);

            int val1 = memo[addrIn1],
                val2 = memo[addrIn2];
            memo[addrOut] = val1 * val2;
            return true;
        }
    }
}