using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        protected long ReadValue(Context ctx, int paramId)
        {
            if (parameters.Length < paramId) throw new InvalidEnumArgumentException("Tried to read params for non-argument operation");
            long paramValue = ctx.ReadParam(paramId + 1);
            int paramMode = parameters[paramId];
            if (ParamMode.Positional == paramMode)
            {
                return ctx.ReadMemory(paramValue);
            }
            else if (ParamMode.Relative == paramMode)
            {
                return ctx.ReadMemory(ctx.RB + paramValue);
            }
            else
            {
                return paramValue;
            }
        }

        protected void WriteValue(Context ctx, int paramId, long value)
        {
            if (parameters.Length < paramId) throw new InvalidEnumArgumentException("Tried to read params for non-argument operation");
            long paramMode = parameters[paramId];
            long paramValue = ctx.ReadParam(paramId + 1);
            long addr;
            if (ParamMode.Positional == paramMode)
            {
                addr = paramValue;
            }
            else if (ParamMode.Relative == paramMode)
            {
                addr = ctx.RB + paramValue;
            }
            else
            {
                throw new AccessViolationException();
            }
            ctx.WriteMemory(addr, value);
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
                parameters[i] = (int) p % 10;
                p /= 10;
            }
        }

        public abstract int OpCode { get; }
        protected abstract bool Process(Context ctx);

        private static class ParamMode
        {
            public const int Positional = 0;
            public const int Immediate = 1;
            public const int Relative = 2;
        }
    }
}