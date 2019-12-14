using System;
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

        public Processor AddCommand(Command command)
        {
            availableCommands.Remove(command.OpCode);
            availableCommands.Add(command.OpCode, command);
            return this;
        }

        public int Execute(Context ctx, params int[] programParams)
        {
            //write params
            for (int i = 0; i < programParams.Length; i++)
            {
                ctx.WriteMemory(1 + i, programParams[i]);
            }
            using (var execution = Run(ctx, programParams))
            {
                while (execution.MoveNext()) { }
                return ctx.ReadMemory(0);
            }
        }
        private IEnumerator<Context> Run(Context ctx, params int[] programParams)
        {
            bool advance = true;
            while (advance)
            {
                int op = ctx.CurrentInstruction % 100;
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
                .AddCommand(new TerminateCommand())
                .AddCommand(new SetValueCmd())
                .AddCommand(new OutputValueCmd());
            return proc;
        }
    }
}