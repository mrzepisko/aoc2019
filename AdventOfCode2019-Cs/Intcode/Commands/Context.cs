using System.Diagnostics;

namespace AdventOfCode2019.Intcode.Commands
{
    public class Context
    {
        public int PC { get; set; }
        private readonly Memory memory;
        private readonly Input input;

        #region ctors

        private Context(Memory memory, Input input)
        {
            PC = 0;
            this.memory = memory;
            this.input = input;
        }

        public static Context Initialize(InteropProgram program)
        {
            Memory memory = Memory.Load(program.Source);
            Input input = Input.Initialize();
            return new Context(memory, input);
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

        #region input

        public int ReadInput()
        {
            return input.Read();
        }
        #endregion
    }
}