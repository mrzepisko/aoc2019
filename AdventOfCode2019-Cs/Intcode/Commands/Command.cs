using System.Diagnostics;

namespace AdventOfCode2019.Intcode
{
    public abstract class Command
    {
        private readonly int opCode;
        private readonly int paramCount;

        public int OpCode => opCode;
        public int Size => paramCount + 1;
        protected Command(int opCode, int paramCount)
        {
            this.opCode = opCode;
            this.paramCount = paramCount;
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
    }
}