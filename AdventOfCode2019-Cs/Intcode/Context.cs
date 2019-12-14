using System.Diagnostics;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Context
    {
        private readonly Memory memory;
        private readonly Stream input;
        private readonly Stream output;

        public long PC { get; set; }
        public long RB { get; set; }
        public long CurrentInstruction => ReadMemory(PC);
        
        public Stream Output => output;
        public Stream Input => input;


        #region ctors

        private Context(Memory memory, Stream input, Stream output)
        {
            PC = 0;
            RB = 0;
            this.memory = memory;
            this.input = input;
            this.output = output;
        }

        public static Context Initialize(long[] source)
        {
            Memory memory = Memory.Load(source);
            Stream input = Stream.Initialize();
            Stream output = Stream.Initialize();
            return new Context(memory, input, output);
        }

        #endregion

        #region memory
        public long ReadParam(long offset)
        {
            return memory[PC + offset];
        }

        public long ReadMemory(long addr)
        {
            return memory[addr];
        }

        public void WriteMemory(long addr, long value)
        {
            memory[addr] = value;
        }
        #endregion
    }
}