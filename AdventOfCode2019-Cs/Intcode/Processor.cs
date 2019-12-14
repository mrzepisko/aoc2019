using System;
using System.Collections.Generic;
using AdventOfCode2019.Intcode.Commands;

namespace AdventOfCode2019.Intcode
{
    public class Processor
    {
        private Dictionary<long, Command> availableCommands;

        private Processor(int size = 0)
        {
            availableCommands = new Dictionary<long, Command>(size);
        }

        public Processor AddCommand(Command command)
        {
            availableCommands.Remove(command.OpCode);
            availableCommands.Add(command.OpCode, command);
            return this;
        }

        public long Execute(Context ctx, params long[] programParams)
        {
            //write params
            for (long i = 0; i < programParams.Length; i++)
            {
                ctx.WriteMemory(1 + i, programParams[i]);
            }
            using (var execution = Run(ctx, programParams))
            {
                while (execution.MoveNext()) { }
                return ctx.ReadMemory(0);
            }
        }

        private IEnumerator<Context> Run(Context ctx, params long[] programParams)
        {
            bool advance = true;
            while (advance)
            {
                long op = ctx.CurrentInstruction % 100;
                var command = GetCommand(op);
                advance = command.Execute(ctx);
                yield return ctx;
                ctx.PC += command.Size;
            }
            yield break;
        }

        private Command GetCommand(long op)
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
            proc.AddCommand(new Add())
                .AddCommand(new MultiplicationCmd())
                .AddCommand(new TerminateCommand())
                
                .AddCommand(new SetValueCmd())
                .AddCommand(new OutputValueCmd())
                
                .AddCommand(new Jit())
                .AddCommand(new Jif())
                .AddCommand(new Lt())
                .AddCommand(new Eq());
            return proc;
        }
    }
}