using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Intcode.Commands
{
    public abstract class Command
    {
        private readonly int[] parameters;

        protected Command(int paramCount)
        {
            parameters = new int[paramCount];
        }

        public int Size => parameters.Length + 1;
        
        protected int ReadValue(Context ctx, int paramId)
        {
            int paramValue = ctx.ReadParam(paramId + 1);
            return parameters[paramId] == 0 ? ctx.ReadMemory(paramValue) : paramValue;
        }

        protected void WriteValue(Context ctx, int paramId, int value)
        {
            if (parameters.Length > 0 && parameters[paramId] == 1) throw new AccessViolationException();
            int paramValue = ctx.ReadParam(paramId + 1);
            ctx.WriteMemory(paramValue, value);
        }

        public bool Execute(Context ctx)
        {
            UpdateParameterModes(ctx);
            return Process(ctx);
        }

        private void UpdateParameterModes(Context ctx)
        {
            var p = ctx.CurrentInstruction / 100; //drop op code
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = p % 10;
                p /= 10;
            }
        }

        public abstract int OpCode { get; }
        protected abstract bool Process(Context ctx);
    }
}