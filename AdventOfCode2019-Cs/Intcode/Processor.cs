using System;
using System.Collections;
using System.Collections.Generic;
using AdventOfCode2019.Intcode.Commands;

namespace AdventOfCode2019.Intcode
{
    public class Processor
    {
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

        public int Execute(InteropProgram program, params int[] programParams)
        {
            using (var execution = Run(program, programParams))
            {
                execution.MoveNext();
                var memory = execution.Current;
                int[] lastMemo = memory;
                while (execution.MoveNext())
                {
                    lastMemo = execution.Current;
                }

                return lastMemo[0];
            }
        }
        private IEnumerator<int[]> Run(InteropProgram program, params int[] programParams)
        {
            //copy program into memory
            int[] memory = new int[program.Source.Length];
            Array.Copy(program.Source, memory, program.Source.Length);
            //copy params into memory
            for (int i = 0; i < programParams.Length; i++)
            {
                memory[1 + i] = programParams[i];
            }
            yield return memory;
            int pc = 0;
            bool advance = true;
            while (advance)
            {
                int op = memory[pc];
                var command = GetCommand(op);
                advance = command.Execute(pc, ref memory);
                yield return memory;
                pc += command.Size;
            }
            yield break;
        }

        private Command GetCommand(int op)
        {
            if (availableCommands.TryGetValue(op, out var cmd))
            {
                return cmd;
            }
            else
            {
                throw new InvalidOperationException($"Invalid opcode {op}");
            }
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