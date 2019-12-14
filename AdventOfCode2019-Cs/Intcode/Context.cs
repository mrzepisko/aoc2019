using System.Diagnostics;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Context
    {
        private readonly Memory memory;
        private readonly Stream input;
        private readonly Stream output;

        public int PC { get; set; }
        public int RB { get; set; }
        public int CurrentInstruction => ReadMemory(PC);
        
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

        public static Context Initialize(int[] source)
        {
            Memory memory = Memory.Load(source);
            Stream input = Stream.Initialize();
            Stream output = Stream.Initialize();
            return new Context(memory, input, output);
        }

        #endregion

        #region memory
        public int ReadParam(int offset)
        {
            return memory[PC + offset];
        }

        public int ReadMemory(int addr)
        {
            return memory[addr];
        }

        public void WriteMemory(int addr, int value)
        {
            memory[addr] = value;
        }
        #endregion
    }
}