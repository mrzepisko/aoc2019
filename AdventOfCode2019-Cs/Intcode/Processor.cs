using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2019.Intcode
{
    public class Processor
    {
        private const int WordSize = 4;

        private Dictionary<int, Command> availableCommands;

        private Processor(int size = 0)
        {
            availableCommands = new Dictionary<int, Command>(size);
        }
        public Processor(List<Command> commands) : this(commands.Count)
        {
            foreach (Command c in commands)
            {
                availableCommands.Add(c.OpCode, c);
            }
        }

        public Processor AddCommand(Command command)
        {
            availableCommands.Remove(command.OpCode);
            availableCommands.Add(command.OpCode, command);
            return this;
        }
        

        public IEnumerator<int[]> Run(InteropProgram program)
        {
            int[] memory = program.Source;
            yield return memory;
            int pc = 0;
            bool advance = true;
            while (advance)
            {
                int op = memory[pc];
                var command = availableCommands[op];
                advance = command.Execute(pc, ref memory);
                yield return memory;
                pc += WordSize;
            }
            yield break;
        }

        public static Processor CreateBasic()
        {
            Processor proc = new Processor();
            proc.AddCommand(new AdditionCmd())
                .AddCommand(new MultiplicationCmd())
                .AddCommand(new TerminateCommand());
            return proc;
        }
    }
}