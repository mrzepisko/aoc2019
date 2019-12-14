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
                var context = execution.Current;
                while (execution.MoveNext())
                {
                    context = execution.Current;
                }

                return context.ReadMemory(0);
            }
        }
        private IEnumerator<Context> Run(InteropProgram program, params int[] programParams)
        {
            //copy program into memory
            Context ctx = Context.Initialize(program);
            for (int i = 0; i < programParams.Length; i++)
            {
                ctx.WriteMemory(1 + i, programParams[i]);
            }
            yield return ctx;
            bool advance = true;
            while (advance)
            {
                int op = ctx.ReadMemory(ctx.PC);
                var command = GetCommand(op);
                advance = command.Execute(ctx);
                yield return ctx;
                ctx.PC += command.Size;
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