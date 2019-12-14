using System.Diagnostics;

namespace AdventOfCode2019.Intcode
{
    public abstract class Command
    {
        private readonly int opCode;

        public int OpCode => opCode;
        protected Command(int opCode)
        {
            this.opCode = opCode;
        }
        
        public bool Execute(int addr, ref int[] memo)
        {
            return memo[addr] != opCode || Process(addr, ref memo);
        }

        private int GetValue(int operation, int offset)
        {
            return operation & offset;
        }
        protected abstract bool Process(int addr, ref int[] memo);

        protected int AddrIn1(int addr, int[] memo) => memo[addr + 1];
        protected int AddrIn2(int addr, int[] memo) => memo[addr + 2];
        protected int AddrOut(int addr, int[] memo) => memo[addr + 3];

        protected static class OpCodes
        {
            public const int Terminate = 99;
            public const int Addition = 1;
            public const int Multiplication = 2;
        }
    }

    public class TerminateCommand : Command
    {
        public TerminateCommand() : base(OpCodes.Terminate) { }

        protected override bool Process(int addr, ref int[] memo) => false;
    }

    public class AdditionCmd : Command
    {
        public AdditionCmd() : base(OpCodes.Addition) { }
        protected override bool Process(int addr, ref int[] memo)
        {
            int addrIn1 = AddrIn1(addr, memo),
                addrIn2 = AddrIn2(addr, memo),
                addrOut = AddrOut(addr, memo);

            int val1 = memo[addrIn1],
                val2 = memo[addrIn2];
            memo[addrOut] = val1 + val2;
            return true;
        }
    }

    public class MultiplicationCmd : Command
    {
        public MultiplicationCmd() : base(OpCodes.Multiplication) { }
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